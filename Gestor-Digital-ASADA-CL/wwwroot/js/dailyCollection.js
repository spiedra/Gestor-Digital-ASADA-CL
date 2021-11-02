const putCollectionOnEditModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;

    $("#inputIdCollection").val(row.cells[0].textContent);
    $("#inputCash").val(row.cells[1].textContent);
    $("#inputCard").val(row.cells[2].textContent);
    $("#inputSINPE").val(row.cells[3].textContent);
    $("#inputTax").val(row.cells[4].textContent);
    $("#inputHydrant").val(row.cells[5].textContent);
    $("#inputInvoice").val(row.cells[6].textContent);
    $("#inputTotal").val(row.cells[7].textContent);
    $('#inputDate').val(moment(new Date(row.cells[8].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
};