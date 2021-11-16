function putCloroOnModal(button) {
    var row = button.parentNode.parentNode;
    $("#inputIdCloro").val(row.cells[0].textContent);
    $("#inputDate").val(moment(new Date(row.cells[1].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#inpuTime").val(row.cells[2].textContent);
    $("#inputPercent").val(row.cells[3].textContent);
    $("#inputIdHouse").val(row.cells[4].textContent);
    $("#inputNameC").val(row.cells[5].textContent);
    //$("#inputNameE").val(row.cells[6].textContent);