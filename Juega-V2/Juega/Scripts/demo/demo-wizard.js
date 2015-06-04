 

(function (window, document, $, undefined) {

    $(function () {
         
        var form = $("#example-form");
        form.validate({
            errorPlacement: function errorPlacement(error, element) { element.before(error); },
            rules: {
                confirm: {
                    equalTo: "#password"
                }
            }
        });

        form.children("div").steps(
        {
            headerTag: "h4",
            bodyTag: "fieldset",
            transitionEffect: "slideLeft",
            onStepChanging: function (event, currentIndex, newIndex)
            { 
                form.validate().settings.ignore = ":disabled,:hidden";
                return form.valid();
            },
            onFinishing: function (event, currentIndex)
            {
                form.validate().settings.ignore = ":disabled";
                return form.valid();
            },
            onFinished: function (event, currentIndex)
            {
                var selects = document.getElementById("cboIdComplejoDeportivo");
                var selectedValue = selects.options[selects.selectedIndex].value;
              
                alert("Valor del complejo:" + selectedValue);
                jQuery.support.cors = true;
                var cancha = {
                    IdCancha: "-1",
                    Nombre: $('#txtNombre').val(),
                    Espectadores: $('#txtNumEspectadores').val(),
                    Largo: $('#txtLargo').val(),
                    Ancho: $('#txtAncho').val(),
                    IdComplejo: selectedValue,
                };

                $.ajax({
                    url: 'http://localhost:54849/Canchas/Crear',
                    type: 'POST',
                    data: JSON.stringify(cancha),
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        // window.location.href = '/Canchas/Inicio/' + id;
                        window.location.href = '/Canchas/Inicio';
                    },
                    error: function (x, y, z) {
                        alert("X:" + x + " Y :" + y + " z :" + z);
                        return;
                    }
                });

                window.location.href = '/Canchas/Inicio'; 
            }
        });

        function WriteResponse(cancha)
        {
            var strResult = "<span class='glyphicon glyphicon-exclamation-sign' aria-hidden='true'></span>  <span class='sr-only'>Error:</span> Ha ocurrido un error al crear la cancha";
            $("#divResult").html(strResult);
        }
        // VERTICAL
        // ----------------------------------- 

        $("#example-vertical").steps({
            headerTag: "h4",
            bodyTag: "section",
            transitionEffect: "slideLeft",
            stepsOrientation: "vertical"
        });

    });

})(window, document, window.jQuery);
