function putOnModal(object) {
    var activity = object.parentNode;
    while (activity.id != "detalle") {
        activity = activity.previousSibling;
    }
    $("#taDetalleModificar").val(activity.textContent);
}