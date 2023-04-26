
var rowUpdated;
var newRow;
var table;
var datatable;
var datatableNoSearch;
var exportedCols = [];

//-----------------------------------------------------> Start::Datatable

// Class definition
var KTDatatables =  function () {


    // Private functions
    var initDatatable = function () {

        // Init datatable --- more info on datatables: https://datatables.net/manual/
        datatable = $(table).DataTable({
            "info": false,
            'pageLength': 10,
        });
    }

    // Hook export buttons
    var exportButtons = () => {
        const documentTitle = $('.js-datatable').data('export-title');
        var buttons = new $.fn.dataTable.Buttons(table, {
            buttons: [
                {
                    extend: 'copyHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportedCols
                    }
                },
                {
                    extend: 'excelHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportedCols
                    }
                },
                {
                    extend: 'csvHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportedCols
                    }
                },
                {
                    extend: 'pdfHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportedCols
                    }
                }
            ]
        }).container().appendTo($('#kt_datatable_example_buttons'));

        // Hook dropdown menu click event to datatable export buttons
        const exportButtons = document.querySelectorAll('#kt_datatable_example_export_menu [data-kt-export]');
        exportButtons.forEach(exportButton => {
            exportButton.addEventListener('click', e => {
                e.preventDefault();

                // Get clicked export value
                const exportValue = e.target.getAttribute('data-kt-export');
                const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                // Trigger click event on hidden datatable export buttons
                target.click();
            });
        });
    }

    // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
    var handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }

    // Public methods
    return {
        init: function () {
            table = document.querySelector('.js-datatable');

            if (!table) {
                return;
            }

            initDatatable();
            exportButtons();
            handleSearchDatatable();
        }
    };
}();


function showSuccessMessage(message = 'Saved Successfully') {


    Swal.fire({
        title: "Success",
        text: message,
        icon: "success",
        buttonsStyling: false,
        confirmButtonText: "Ok",
        customClass: {
            confirmButton: "btn btn-primary"
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $('.js-edition-status').parents('tr').removeClass('animate__animated animate__flash');
            $('tbody').find('.js-new-row').removeClass('animate__animated animate__flash');
            $('tbody').find('.js-new-row').removeClass('js-new-row');
        }

    });
}


function showErorrMessage(message = 'Something Went Wrong!') {


    if (typeof message !== 'string') {
        message = 'Something Went Wrong!';
    }

    Swal.fire({
        title: "Ooops...!",
        text: message,
        icon: "error",
        buttonsStyling: false,
        confirmButtonText: "Ok",
        customClass: {
            confirmButton: "btn btn-primary"
        }
    });


}

function disableSubmitBtn(){
    $('body :submit').attr('data-kt-indicator', 'on').attr('disabled', 'disabled');

}

function onModalBegin() {

    disableSubmitBtn();
}

function modalSubmitSuccess(row) {
    $('#Modal').modal('hide');

    addNewRow(row);
    $('tbody').find('.js-new-row').addClass('animate__animated animate__flash');
    showSuccessMessage();

    KTMenu.init();
    KTMenu.initHandlers();

}

function onModalComplete() {

    $('body :submit').removeAttr('data-kt-indicator', 'on').removeAttr('disabled', 'disabled');


}


$(document).ready(function () {
    //select2

    $('.js-select2').select2();
    $('.js-select2').on('select2:select', function (e) {

        $('form').validate().element('#' + $(this).attr('id'));

    });
    
    //Disable Submit Button

    $('form').on('submit', function () {

        var isValid = $(this).valid();

        if (isValid) disableSubmitBtn();

    });

    //DateRangePicker

    $('.js-daterangepicker').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        autoApply: true,
        drops: 'auto',
        maxDate: new Date()
    });

    //datatable with search
    var headers = $('.js-datatable th');
    $.each(headers, function (i) {
        if (!$(this).hasClass('js-no-export'))
            exportedCols.push(i);

    });

    KTUtil.onDOMContentLoaded(function () {

        KTDatatables.init();
    });

    //datatable without search

    datatableNoSearch = $('.js-datatable-non').DataTable({

    });

    $('body').delegate('.js-delete-btn', 'click', function () {

        var btn = $(this);

        bootbox.confirm({
            title: btn.data('title'),
            message: 'Are You Sure That You Want To Change The Status',
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times"></i> Cancel',
                    className: 'btn-primary'

                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Confirm',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {

                    btn.parents('tr').removeClass('animate__animated animate__flash');


                    $.post
                        (
                            {
                                url: btn.data('url'),
                                data: {
                                    '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                                },
                                success: function () {

                                    confirmBoxSuccess(btn);
                                    showSuccessMessage();

                                },
                                error: function () {
                                    showErorrMessage();
                                }

                            }

                        )

                }
            }
        });

    });

    //Handle Modal
    $('body').delegate('.js-render-modal', 'click', function () {

        var btn = $(this);
        var modal = $('#Modal');

        if (btn.data('is-edited') !== undefined) {
            rowUpdated = btn.parents('tr');
            rowUpdated.removeClass('animate__animated animate__flash');

        }


        $.get({

            url: btn.data('url'),

            success: function (form) {
                modal.find('.modal-title').text(btn.data('title'));
                modal.find('.modal-body').html(form);
                $.validator.unobtrusive.parse(modal);
                $('.js-select2').select2();
                modal.modal('show');


            },

            error: function () {
                showErorrMessage();
            }
        })



    });

});