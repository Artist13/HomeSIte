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
        
    }
    
    return false;
}   
function OnSuccess()
{
    document.getElementById('mask').style.display = "block";
}
function OnFailure()
{
    alert("Что-то пошло не так")
}