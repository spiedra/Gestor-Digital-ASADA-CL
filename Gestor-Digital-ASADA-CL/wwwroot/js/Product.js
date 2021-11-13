function putOnModal(button) {
    row = button.parentNode.parentNode;
    code = row.cells[0].textContent;
    name = row.cells[1].textContent;
    unit_value = row.cells[2].textContent;
    amount = row.cells[3].textContent;
    date_in = row.cells[4].textContent;
    description = row.cells[5].textContent;

    $("#codigo").val(code);
    $("#nombre").val(name);
    $("#valor").val(unit_value);
    $("#cantidad").val(amount);
    $('#fechaE').val(moment(new Date(date_in)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#descripcion").text(description);
}

function putOnModalDelete(buttonContext) {
    const msgContainerDeleteModal = $('#msgContainerDeleteModal');
    row = buttonContext.parentNode.parentNode;
    code = row.cells[0].textContent;

    msgContainerDeleteModal.empty();
    $("#productCode").val(code);
    msgContainerDeleteModal.append('El producto con el codigo <p class="fw-bold d-inline">' + code + '</p> va a ser borrado permanentemente del sistema');
}

function putOnModalReport(button) {
    row = button.parentNode.parentNode;
    if (parseInt(row.cells[3].textContent) == 0) {
        createModalResponse2("No hay cantidad disponible.");
    } else {
        code = row.cells[0].textContent;
        document.getElementById("productoSolicitado").innerHTML = "Toma de producto: " + row.cells[1].textContent;
        $("#productoS").val(code);
    }
}