common = {
    functions: {
        getFormData: function ($form) {
            var unindexed_array = $form.serializeArray();
            var indexed_array = {};

            $.map(unindexed_array, function (n, i) {
                indexed_array[n['name']] = n['value'];
                if ($form[0].elements[n['name']].type == "checkbox") {
                    indexed_array[n['name']] = $form[0].elements[n['name']].checked;
                }
            });

            return indexed_array;
        },
        resetGridWidth: function (grid) {
            grid.jqGrid("setGridWidth", grid.closest(".ui-jqgrid").parent().width(), true);
        },
        resetGridHeight: function (grid) {
            grid.jqGrid("setGridHeight", common.configs.mainGrid.getHeight(), true);
        },
        openInNewTab: function (url) {
            var win = window.open(url, '_blank');
            win.focus();
        },
        getDimDate: function (jsDate) {
            if (jsDate !== null) {
                return jsDate.getFullYear() * 10000
                    + (jsDate.getMonth() + 1) * 100
                    + jsDate.getDate();
            } else {
                return 0;
            }
        },
        getDimTime: function (jsTime) {
            if (jsTime !== null && jsTime.length > 0) {
                console.log(parseInt(jsTime.substring(0, 2)) * 100 + parseInt(jsTime.substring(3, 5)));
                return parseInt(jsTime.substring(0, 2)) * 100 + parseInt(jsTime.substring(3, 5));
            } else {
                return 0;
            }
        },
        parseDate8601Long: function (date) {
            return new Date(parseInt(date.substr(6)));
        }
    },
    configs: {
        mainGrid: {
            getHeight: function () {
                return window.innerHeight - 180;
            },
            getRowNum: function () {
                return parseInt(this.getHeight() / 23);
            },
            getRowList: function () {
                return [this.getRowNum(), 30, 40, 50, 100];
            }
        },
        grid: {
            dateFormatOption: { srcformat: "ISO8601Long", newformat: "d/m/Y" },
            datetimeFormatOption: { srcformat: "ISO8601Long", newformat: "d/m/Y h:i:s A" },
            dayMonthFormatOption: { srcformat: "ISO8601Long", newformat: "d/m h:i:s A" },
            monthYearFormatOption: { srcformat: "ISO8601Long", newformat: "m/Y" }
        }
    },
}