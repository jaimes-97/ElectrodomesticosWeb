$(document).ready(function () {

    $('.lightbox_trigger').click(function (e) {
        $('body').css("overflow-y", "hidden");
        $('body').css("overflow-x", "hidden");
     
        
        e.preventDefault();

        //obetener el src de la imagen clickeada
        var image_href = $(this).attr("src");

       //ver si ya existia un lightbox

        if ($('#lightbox').length > 0) { // #lightbox existe

            //ponerle el valor del src
            $('#content').html('<img src="' + image_href + '" />');

            //mostrar el lightbox
            $('#lightbox').show();
        }

        else { //se crea dinamicamente el lightbox

            
            var lightbox =
			'<div id="lightbox">' +
				'<p>Click to close</p>' +
				'<div id="content">' + //insert clicked link's href into img src
					'<img src="' + image_href + '" />' +
				'</div>' +
			'</div>';

            //insertar en el html el lightbox
            $('body').append(lightbox);
            //bloquear el scroll
        
           
        }



    });

  


    //Clickear en cualquier lado para desactivar el lightbox
    $('body').on('click', "#lightbox", function () { 
        
        $('#lightbox').hide();
        $('body').css("overflow-y", "scroll");
        $('body').css("overflow-x", "scroll");
    });
   


});
