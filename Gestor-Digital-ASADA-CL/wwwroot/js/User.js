var idUsuario;

const putUserOnEditModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    const currentJobName = row.cells[6].textContent;
    const selectJobs = $('#selectJobsEditModal');

    $("#inputIdUser").val(row.cells[0].textContent);
    $("#inputIdCard").val(row.cells[1].textContent);
    $("#inputName").val(row.cells[2].textContent);
    $("#inputLastName").val(row.cells[3].textContent);
    $("#inputUserName").val(row.cells[4].textContent);
    $("#inputPassword").val(row.cells[5].textContent);

    $.ajax({
        url: '/User/GetRolesByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            selectJobs.empty();
            response.forEach(element => {
                if (element.tipoRole === currentJobName) {
                    selectJobs.append('<option id=' + element.idRole + ' class="select_opcion" selected>' + element.tipoRole + '</option>');
                } else {
                    selectJobs.append('<option id=' + element.idRole + ' class="select_opcion">' + element.tipoRole + '</option>');
                }
            });
        }
    });
};

const putRolesOnAddModal = () => {
    const selectJobsNamesAddModal = $(".selectJobNames");

    $.ajax({
        url: '/User/GetRolesByAjax',
        type: 'get',
        dataType: 'json',
        success: function (response) {
            selectJobsNamesAddModal.empty();
            selectJobsNamesAddModal.prepend('<option class="select_opcion" value="" selected>Seleccione algún puesto</option>');
            response.forEach(element => {
                selectJobsNamesAddModal.append('<option class="select_opcion">' + element.tipoRole + '</option>');
            });
        }
    });
};

const createInputHiddenOnDeleteUserModal = (buttonContext) => {
    row = buttonContext.parentNode.parentNode;
    $('<input>').attr({
        type: 'hidden',
        name: 'idUser',
        value: row.cells[0].textContent
    }).appendTo('#msgContainerDeleteModal');
};

const putUserFullNameOnDeleteModal = (buttonContext) => {
    const msgContainerDeleteModal = $('#msgContainerDeleteModal');
    row = buttonContext.parentNode.parentNode;

    msgContainerDeleteModal.empty();
    createInputHiddenOnDeleteUserModal(buttonContext);
    msgContainerDeleteModal.append('El usuario <p class="fw-bold d-inline">' + row.cells[2].textContent + ' ' + row.cells[3].textContent + '</p> va a ser borrado permanentemente del sistema');
};