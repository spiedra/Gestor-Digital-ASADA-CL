function putCloroOnModal(button) {
    var row = button.parentNode.parentNode;
    var option = $('.sedit option:first-child')
    if (option.data('last') === undefined){
    } else {
        option.remove();
    }
    $("#inputIdCloro").val(row.cells[0].textContent);
    $("#inputDate").val(moment(new Date(row.cells[1].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#inputPercent").val(row.cells[2].textContent);
    $("#inputIdHouse").val(row.cells[3].textContent);
    $("#inputNameC").val(row.cells[4].textContent);
    $("#inputDetails").val(row.cells[6].textContent);
    putWorkerNameOnEditModal(row.cells[5].textContent);
}

const putWorkerNameOnEditModal = (currentWorkerName) => {
    const workerNameSelect = $("#workerNameSelect");

    $.ajax({
        url: '/Cloro/GetFontanerosByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            workerNameSelect.empty();
            workerNameSelect.prepend('<option class="select_opcion" value="" selected>Seleccione algún fontanero</option>');
            response.forEach(element => {
                if ((element.nombre + " " + element.apellidos) === currentWorkerName) {
                    workerNameSelect.append('<option id=' + element.idUsuario + ' class="select_opcion" selected>' + element.nombre + " " + element.apellidos + '</option>');
                } else {
                    workerNameSelect.append('<option id=' + element.idUsuario + ' class="select_opcion">' + element.nombre + " " + element.apellidos + '</option>');
                }
            });
        }
    });
};
