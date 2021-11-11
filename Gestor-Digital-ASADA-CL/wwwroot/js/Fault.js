function putFaultOnModal(button) {
    var row = button.parentNode.parentNode;
    $("#inputIdAveria").val(row.cells[0].textContent);
    $("#inputName").val(row.cells[1].textContent);
    $("#inputDateR").val(moment(new Date(row.cells[3].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#inputDateE").val(moment(new Date(row.cells[4].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#details").val(row.cells[5].textContent);
    $("#Work").val(row.cells[6].textContent);

}

const createInputHiddenOnDeleteFaultModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    $('<input>').attr({
        type: 'hidden',
        name: 'idFault',
        value: row.cells[0].textContent
    }).appendTo('#formDeleteModal');
};
