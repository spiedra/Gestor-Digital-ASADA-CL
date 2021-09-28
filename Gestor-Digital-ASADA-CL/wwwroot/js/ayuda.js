
$("#mis_tareas").hover(function In() {
    $("#consejo_tareas").show();
    $(".bienvenida").css("display", "none");
    $(".estructura_consejo_tareas").css("display", "flex");
}, function Out() {
    $("#consejo_tareas").hide();
    $(".bienvenida").css("display", "block");
    $(".estructura_consejo_tareas").css("display", "none");
});

$("#inventario").hover(function In() {
    $("#consejo_inventario").show();
    $(".bienvenida").css("display", "none");
    $(".estructura_consejo_inventario").css("display", "flex");
}, function Out() {
    $("#consejo_inventario").hide();
    $(".bienvenida").css("display", "block");
    $(".estructura_consejo_inventario").css("display", "none");
});

$("#cloros").hover(function In() {
    $("#consejo_cloros").show();
    $(".bienvenida").css("display", "none");
    $(".estructura_consejo_cloros").css("display", "flex");
}, function Out() {
    $("#consejo_cloros").hide();
    $(".bienvenida").css("display", "block");
    $(".estructura_consejo_cloros").css("display", "none");
});

$("#mi_bitacora").hover(function In() {
    $("#consejo_bitacora").show();
    $(".bienvenida").css("display", "none");
    $(".estructura_consejo_bitacora").css("display", "flex");
}, function Out() {
    $("#consejo_bitacora").hide();
    $(".bienvenida").css("display", "block");
    $(".estructura_consejo_bitacora").css("display", "none");
});



