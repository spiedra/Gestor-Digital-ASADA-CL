const putCollectionOnEditModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;

    $('#inputDate').val(moment(new Date(row.cells[1].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#inputCash").val(row.cells[2].textContent);
    $("#inputCard").val(row.cells[3].textContent);
    $("#inputSINPE").val(row.cells[4].textContent);
    $("#inputTax").val(row.cells[5].textContent);
    $("#inputHydrant").val(row.cells[6].textContent);
    $("#inputInvoice").val(row.cells[7].textContent);
    $("#inputTotal").val(row.cells[8].textContent);
};