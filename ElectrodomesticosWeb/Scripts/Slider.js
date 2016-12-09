$("document").ready(function () {

    var imagenes = new Array("electro1.jpg", "electro.jpg");

    function rotarImagenes() {
        var indice = 0;
        document.getElementById("slider").src = "./Electrodomesticos/" + imagenes[indice];
        indice++;
        if (indice > imagenes.length) {
            indice = 0;
        }

    }

    function timer() {

        rotarImagenes();

        setInterval(rotarImagenes, 2000);
    }
    onload = timer();
    });