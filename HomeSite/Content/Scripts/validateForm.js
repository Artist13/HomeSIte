function validate_form() {
    valid = true;

    if (document.getElementById("email").value == "") {
        alert("Пожалуйста заполните поле 'E-mial'");
        valid = false;
    }
    if (document.getElementById("person").value == "") {
        alert("Пожалуйста заполните поле 'Имя'");
        valid = false;
    }


    return valid;
}
function OnSuccess(data) {
    document.getElementById('mask').style.display = "block";
    setTimeout("document.location.href='http://localhost:19070/'", 5000);
}
function OnFailure(request, error) {
    alert("Что-то пошло не так")
}