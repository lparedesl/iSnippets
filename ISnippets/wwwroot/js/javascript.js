var Datatables = function () {

    var initSnippetsTable = function () {

        var table = $('#snippets-table');

        table.DataTable({
            language: {
                url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/English.json'
            },

            lengthMenu: [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"]
            ],
            pageLength: 10,
            pagingType: "full_numbers",
            columnDefs: [
                {
                    orderable: false,
                    targets: [3]
                },
                {
                    searchable: false,
                    targets: [3]
                },
                {
                    className: "dt-right"
                }
            ]
        });
    };

    return {
        init: function () {
            initSnippetsTable();
        }

    };
}();

var CodeEditors = function () {

    var editCreate = function () {
        var myTextArea = document.getElementById('CodeSnippet');
        if (myTextArea) {
            var myCodeMirror = CodeMirror.fromTextArea(myTextArea,
                {
                    lineNumbers: true,
                    matchBrackets: true,
                    styleActiveLine: true,
                    theme: "ambiance"
                });
        }
    };

    var details = function () {
        var myTextArea = document.getElementById('code_editor_details');
        if (myTextArea) {
            var myCodeMirror = CodeMirror.fromTextArea(myTextArea,
                {
                    lineNumbers: true,
                    matchBrackets: true,
                    styleActiveLine: true,
                    theme: "ambiance",
                    readOnly: true
                });
        }
    };

    return {
        init: function () {
            editCreate();
            details();
        }
    };

}();

jQuery(document).ready(function () {
    CodeEditors.init();
    Datatables.init();
});
