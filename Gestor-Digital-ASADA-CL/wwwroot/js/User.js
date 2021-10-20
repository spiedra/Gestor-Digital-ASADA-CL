const putUserOnModal = (button) => {
    row = button.parentNode.parentNode;
    idCard = row.cells[0].textContent;
    name = row.cells[1].textContent;
    lastName = row.cells[2].textContent;
    userName = row.cells[3].textContent;
    password = row.cells[4].textContent;

    $("#inputIdCard").val(idCard);
    $("#inputName").val(name);
    $("#inputLastName").val(lastName);
    $("#inputUserName").val(userName);
    $("#inputPassword").val(password);
}