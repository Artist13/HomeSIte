var Days = [];
var month = new Date().getMonth();
var year = new Date().getFullYear();
function calendar1(id, year, month, days) {
    var Dlast = new Date(year, month + 1, 0).getDate(),
        D = new Date(year, month, Dlast),
        DNlast = new Date(D.getFullYear(), D.getMonth(), Dlast).getDay(),
        DNfirst = new Date(D.getFullYear(), D.getMonth(), 1).getDay(),
        calendar = '<tr>',
        Month = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
    if (DNfirst != 0) {
        for (var i = 1; i < DNfirst; i++) calendar += '<td>';
    } else {
        for (var i = 0; i < 6; i++) calendar += '<td>';
    }
    var istoday = 0;
    if (month > new Date().getMonth())
        istoday = 1;
    for (var i = 1; i <= Dlast; i++) {
        if (i == new Date().getDate() && D.getFullYear() == new Date().getFullYear() && D.getMonth() == new Date().getMonth()) {
            if (days[i - 1] == '1') {
                istoday = 1;
                calendar += '<td class=" cell today reserv">' + i;
            }
            else {
                istoday = 1;
                calendar += '<td class="cell today clear">' + i;
            }
        } else {
            if (days[i - 1] == '1')
                switch (istoday) {
                    case 0:
                        calendar += '<td class="befortoday cell reserv">' + i;
                        break;
                    case 1:
                        calendar += '<td class="cell reserv">' + i;
                        break;
                }
            else
                switch (istoday) {
                    case 0:
                        calendar += '<td class="befortoday cell clear">' + i;
                        break;
                    case 1:
                        calendar += '<td class="cell clear">' + i;
                        break;
                }

        }
        if (new Date(D.getFullYear(), D.getMonth(), i).getDay() == 0) {
            calendar += '<tr>';
        }
    }
    for (var i = DNlast; i < 7; i++) calendar += '<td>&nbsp;';
    document.querySelector('#' + id + ' tbody').innerHTML = calendar;
    document.querySelector('#' + id + ' thead td:nth-child(2)').innerHTML = Month[D.getMonth()] + ' ' + D.getFullYear();
    document.querySelector('#' + id + ' thead td:nth-child(2)').dataset.Month = D.getMonth();
    document.querySelector('#' + id + ' thead td:nth-child(2)').dataset.year = D.getFullYear();
    if (document.querySelectorAll('#' + id + ' tbody tr').length < 6) {  // чтобы при перелистывании месяцев не "подпрыгивала" вся страница, добавляется ряд пустых клеток. Итог: всегда 6 строк для цифр
        document.querySelector('#' + id + ' tbody').innerHTML += '<tr><td>&nbsp;<td>&nbsp;<td>&nbsp;<td>&nbsp;<td>&nbsp;<td>&nbsp;<td>&nbsp;';
    }
}

//Обновление данных календаря
//Доработать: запрашивать данные на каждый месяц только один раз
function UpdateDays(month) {
    $.ajax({
        url: "GetDate",
        data: {
            month: (month + 1),
            room: window.location.search.split('?')[1].split('=')[1]},
        success: function (data) {
            Days[month] = data;
            calendar1("calendar1", new Date().getFullYear(), month, Days[month]);
            calend();
        }
    });
}
//обновление отображения доступности переключателя
function UpdateArrows() {
    if ((month == 5) || (month == new Date().getMonth())) {
        $("#left_arrow").addClass("unready");
    }
    else {
        $("#left_arrow").removeClass("unready");
    }
    if (month == 8) {
        $("#right_arrow").addClass("unready");
    }
    else {
        $("#right_arrow").removeClass("unready");
    }
}
//функция выполняющаяся при загрузке страницы
$(document).ready(function () {
    UpdateDays(new Date().getMonth());
    UpdateArrows();
})

// переключатель минус месяц
$("#left_arrow").click(function () {
    if ((month > new Date().getMonth()) && (month > 5)) {
        month = month - 1;
        //if (Days[month] != undefined)
            UpdateDays(month);
    }
    UpdateArrows();
})

// переключатель плюс месяц
$("#right_arrow").click(function () {
    if (month < 8) {
        month = month + 1;
        //if (Days[month] != undefined)
            UpdateDays(month);
    }
    UpdateArrows();
})
var start;//День приезда
var start_day;
var start_month
var finish;//День отъезда
var finish_day;
var finish_month;
var cl = 0;//Какая из строк активна
//Подсвечивание при нажатии
$("table").click(function (e) {
    if ($(this).find(e.target).hasClass("cell") && !($(e.target).hasClass("befortoday")) && !($(e.target).hasClass("reserv"))) {
        switch (cl) {
            case 0:
                if (finish != undefined) {
                    //очистка всех элементов кроме конечного
                    $.each($("#calendar1 tr td.cell"), function (index, value) {
                        if (index != $("#calendar1 tr td.cell").index(finish)) {
                            $(this).removeClass("reservNow");
                        };
                    });
                    //----------------------------------------
                };
                $(start).removeClass("reservNow");
                start = e.target;
                start_day = start.innerHTML;
                start_month = month;
                $(start).addClass("reservNow");
                setTimeout(function () {
                    $("#calendar1").css({ "visibility": "hidden" });
                }, 200);

                if (finish != undefined) {
                    calend();
                };
                RefreshDate();
                break;
            case 1:
                if (typeof (start) != "undefined") {
                    //очистка всех элементов кроме начального
                    $.each($("#calendar1 tr td.cell"), function (index, value) {
                        if (index != $("#calendar1 tr td.cell").index(start)) {
                            $(this).removeClass("reservNow");
                        };
                    });
                    //----------------------------------------
                };
                $(finish).removeClass("reservNow");
                finish = e.target;
                finish_day = finish.innerHTML;
                finish_month = month;
                $(finish).addClass("reservNow");
                setTimeout(function () {
                    $("#calendar1").css({ "visibility": "hidden" });
                }, 200);

                if (start != undefined) {
                    calend();
                };
                RefreshDate();
                break;
        }
    }
});
//Обновление данных в полях ввода
function RefreshDate() {
    if (start == undefined) {
        $("#datepicker_input").val("");
    }
    else {
        if (start_day.toString().length < 2)
            var day = "0" + start_day;
        else
            var day = start_day;
        if ((start_month + 1).toString().length < 2)
            var Month = "0" + (start_month + 1);
        else
            var Month = start_month + 1;
        $("#datepicker_input").val(year + "-" + Month + "-" + day);
    }
    if (finish == undefined) {
        $("#datepicker_output").val("");
    }
    else {
        if (finish_day.toString().length < 2)
            var day = "0" + finish_day;
        else
            var day = finish_day;
        if ((finish_month + 1).toString().length < 2)
            var Month = "0" + (finish_month + 1);
        else
            var Month = finish_month + 1;
        $("#datepicker_output").val(year + "-" + Month + "-" + day);
    }
}
//Отрисовка выбранных дней 
function calend() {
    if ((start != undefined) && (finish != undefined)) {
        //Проверка правильности порядка
        if ((start_month - 0 > finish_month - 0) || ((start_month == finish_month) && (start_day - 0 > finish_day - 0))) {
            $(finish).removeClass("reservNow");
            finish_day = undefined;
            finish_month = undefined;
            finish = undefined;
        }
        else {
            //Проход по всем месяцам от начального до конечного
            for (var temp_month = start_month; temp_month <= finish_month; temp_month++) {
                if (temp_month == start_month)
                    var init = start_day - 1;
                else
                    var init = 0;
                if (temp_month == finish_month)
                    var last = finish_day;
                else
                    var last = Days[temp_month].length;
                for (var temp_day = init; temp_day < last; temp_day++) {
                    if (Days[temp_month][temp_day] == 1) {
                        $(finish).removeClass("reservNow");
                        finish = $("#calendar1 tr td.cell")[temp_day - 1];
                        finish_day = temp_day;
                        finish_month = temp_month;
                        break;
                    }
                    else {
                        if (temp_month == month) {
                            $($("#calendar1 tr td.cell")[temp_day]).addClass("reservNow");
                        }
                    }
                }
            }
        }
    }
};
//Появление календаря при нажатии на строку приезда
$("#datepicker_input").click(function (e) {
    cl = 0;
    $("#calendar1").offset({ top: $("#datepicker_input").offset().top + $("#datepicker_input").outerHeight(), left: $("#datepicker_input").offset().left });
    e.preventDefault();
    $("#calendar1").css({ "visibility": "visible" });
});
//Появления календаря при нажатии на строку отъезда
$("#datepicker_output").click(function (e) {
    cl = 1;
    $("#calendar1").offset({ top: $("#datepicker_output").offset().top + $("#datepicker_output").outerHeight(), left: $("#datepicker_output").offset().left });
    e.preventDefault();
    $("#calendar1").css({ "visibility": "visible" });
});