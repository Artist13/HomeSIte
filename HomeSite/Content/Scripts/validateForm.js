function validate_form(form) {
    valid = true;

    if (document.getElementById("email").value == "") {
        alert("Пожалуйста заполните поле 'E-mial'");
        valid = false;
    }
    if (document.getElementById("person").value == "") {
        alert("Пожалуйста заполните поле 'Имя'");
        valid = false;
    }
    if (valid)
    {
        document.getElementById('mask').style.display = "block";
        setTimeout(redirect, 3000);
    }
    
    return false;
}   
function redirect()
{
    document.getElementById('reserv').submit();
}