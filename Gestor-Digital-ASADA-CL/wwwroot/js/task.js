const getTasksByUserId = (buttonContext) => {
    var userId = $(buttonContext).val();
    changeUserNameOfLabel($(buttonContext).attr("name"), userId);
    setTasksOnTbodyTask(userId);
};

const changeUserNameOfLabel = (userFullName, userId) => {
    var tagUserFullName = $('#tagUserFullName');
    tagUserFullName.empty();
    tagUserFullName.attr("userId", userId);
    tagUserFullName.append("Usuario: " + userFullName);
};

const addTask = () => {
    var userId = $('#tagUserFullName').attr('userId');
    if ($("#appForm").valid()) {
        if (userId != null) {
            $.ajax({
                url: '/Task/Create',
                type: 'post',
                data: {
                    "UserId": userId,
                    "Title": $('#inputTitle').val(),
                    "Details": $('#inputDetail').val(),
                },
                dataType: 'json',
                success: function (response) {
                    setTasksOnTbodyTask(userId);
                    $('#addModal').modal('hide');
                    createModalResponse2(response);
                }
            });
        } else {
            $('#addModal').modal('hide');
            createModalResponse2("Usuario no seleccionado. Intentelo de nuevo");
        }
    }
};

const setTasksOnTbodyTask = (userId) => {
    var tbodyTable = $('#tbodyTask');

    $.ajax({
        url: '/Task/GetTasksByUserId',
        type: 'get',
        data: {
            "UserId": userId
        },
        dataType: 'json',
        success: function (response) {
            tbodyTable.empty();
            if (response.length != 0) {
                $(".toast").toast('hide');
                response.forEach(element => {
                    tbodyTable.append($('<tr>')
                        .append($('<td>').append(element['idTarea']))
                        .append($('<td>').append(element['titulo']))
                        .append($('<td>').append(element['detalles']))
                        .append($('<td>').append(
                            $('<button class="btn btn-primary btn-sm my-1 me-1 my-xl-0" data-bs-toggle="modal" data-bs-target="#editModal">'
                                + 'Modificar <img src="/assets/edit_white_18dp.svg" alt="Icono eliminar usuario" class= "my-1"/></button >'
                            )).append($('<button class="btn btn-danger btn-sm my-1 my-xl-0" data-bs-toggle="modal" data-bs-target="#deleteModal">'
                                + 'Eliminar <img src="/assets/delete_white_18dp.svg" alt="Icono eliminar usuario" class="my-1" /></button>'
                            )))
                    )
                });
            } else {
                $(".toast").toast('show');
            }
        }
    });
}