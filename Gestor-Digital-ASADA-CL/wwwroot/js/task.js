const getTasksByUserId = (buttonContext) => {
    var tbodyTable = $('#tbodyTask');
    changeUserNameOfLabel($(buttonContext).attr("name"));

    $.ajax({
        url: '/Task/GetTasksByUserId',
        type: 'get',
        data: {
            "UserId": $(buttonContext).val()
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
};

const changeUserNameOfLabel = (userFullName) => {
    var tagUserFullName = $('#tagUserFullName');
    tagUserFullName.empty();
    tagUserFullName.append("Usuario: " + userFullName);
};