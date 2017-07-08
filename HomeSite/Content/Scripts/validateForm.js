function validate_form() {
    valid = true;

    if (document.getElementById("Email").value == "") {
        alert("Пожалуйста заполните поле 'E-mial'");
        valid = false;
    }
    if (document.getElementById("person").value == "") {
        alert("Пожалуйста заполните поле 'Имя'");
        valid = false;
    }

    return valid;
}