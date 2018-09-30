//DOM ready, when html loaded
$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this); //the form submitted

        var options = {
            url: $form.attr("action"),  //data
            type: $form.attr("method"), //get
            data: $form.serialize() //data to send to server
        }

        //async call - response in data object
         $.ajax(options).done(function (data) {
             var $target = $($form.attr("data-me-target"));
             var $newHtml = $(data);

             $target.replaceWith(data);
             $newHtml.effect("highlight");
        });

        //Prevents the navigation.
        return false;
    }

    var createAutoComplete = function () {
        var $input = $(this); //The textbox

        var options = {
            source: $input.attr("data-me-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);//Jquery UI that autocompletes

        return false;
    };

    //Called when one selected
    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this); //The textbox

        $input.val(ui.item.label); //Set the value, ui passed in by autocomplete, has state about it eg label

        var $form = $input.parents("form:first"); //encase a form in a form, take the first one
        $form.submit();//goes back into ajax form submit
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $form.serialize(),//Adds form data and sends them in the request too. 
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var $target = $a.parents("div.pagedList").attr("data-me-target");
            $target.replaceWith(data);
        });

        return false;
    };

    //Wire events to this
    $("form[ data-me-ajax='true']").submit(ajaxFormSubmit);

    //Get all inputs and create when received
    $("input[data-me-autocomplete]").each(createAutoComplete);

    $(".main-content").on("click", ".pagedList a", getPage);
});
