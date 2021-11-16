function putSectorOnModal(button) {
    var row = button.parentNode.parentNode;
    $("#inputIdSector").val(row.cells[0].textContent);
    $("#inputName").val(row.cells[1].textContent);
    

}

const createInputHiddenOnDeleteSectorModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    $('<input>').attr({
        type: 'hidden',
        name: 'id',
        value: row.cells[0].textContent
    }).appendTo('#formDeleteModal');
};