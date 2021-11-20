function putFaultOnModal(button) {
    var row = button.parentNode.parentNode;
    $("#inputIdAveria").val(row.cells[0].textContent);
    $("#inputName").val(row.cells[1].textContent);
    $("#inputDateR").val(moment(new Date(row.cells[3].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#inputDateE").val(moment(new Date(row.cells[4].textContent)).format('YYYY-MM-DDThh:mm:ss.SSS'));
    $("#details").val(row.cells[5].textContent);
    $("#Work").val(row.cells[6].textContent);
    putSectorOnEditModal(row.cells[2].textContent);
    putWorkerNameOnEditModal(row.cells[7].textContent);
}

const createInputHiddenOnDeleteFaultModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    $('<input>').attr({
        type: 'hidden',
        name: 'idFault',
        value: row.cells[0].textContent
    }).appendTo('#formDeleteModal');
};

const putSectorOnEditModal = (currentSector) => {
    const sectorSelect = $("#sectorSelectEditModal");

    $.ajax({
        url: '/Fault/GetSectorsByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            sectorSelect.empty();
            sectorSelect.prepend('<option class="select_opcion" value="" selected>Seleccione algún sector</option>');
            console.log(response)
            response.forEach(element => {
                if (element.nombreSector === currentSector) {
                    sectorSelect.append('<option value=' + element.idSector + ' class="select_opcion" selected>' + element.nombreSector + '</option>');
                } else {
                    sectorSelect.append('<option value=' + element.idSector + ' class="select_opcion">' + element.nombreSector + '</option>');
                }
            });
        }
    });
};

const putWorkerNameOnEditModal = (currentWorkerName) => {
    const workerNameSelect = $("#workerNameSelect");

    $.ajax({
        url: '/Fault/GetFontanerosByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            workerNameSelect.empty();
            workerNameSelect.prepend('<option class="select_opcion" value="" selected>Seleccione algún fontanero</option>');
            response.forEach(element => {
                if ((element.nombre + " " + element.apellidos) === currentWorkerName) {
                    workerNameSelect.append('<option value=' + element.idUsuario + ' class="select_opcion" selected>' + element.nombre + " " + element.apellidos + '</option>');
                } else {
                    workerNameSelect.append('<option value=' + element.idUsuario + ' class="select_opcion">' + element.nombre + " " + element.apellidos + '</option>');
                }
            });
        }
    });
};
