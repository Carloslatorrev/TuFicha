var SelectHelper = (function () {
    function SelectHelper(_selectName, _url, _place, _clear, _multiple, _tag, _data) {
        if (_data === void 0) { _data = null; }
        this.selectName = _selectName;
        this.url = _url;
        this.allowClear = _clear;
        this.placeholder = _place;
        this.allowMultiple = _multiple;
        this.allowTag = _tag;
        this.data = _data;
        this.Events = new EventsHelper();
    }
    SelectHelper.prototype.initSelect = function () {
        $(this.selectName).select2({
            tags: this.allowTag,
            multiple: this.allowMultiple,
            allowClear: this.allowClear,
            placeholder: this.placeholder,
            theme: "bootstrap",
            tokenSeparators: [',', ' '],
        });
        this.Events.call("OnInitSelect");
    };
    ;
    SelectHelper.prototype.initSelectAjax = function () {
        $(this.selectName).select2({
            tags: this.allowTag,
            multiple: this.allowMultiple,
            allowClear: this.allowClear,
            placeholder: this.placeholder,
            theme: "bootstrap",
            tokenSeparators: [',', ''],
            minimumInputLength: 3,
            minimumResultsForSearch: 10,
            language: {
                inputTooShort: function () {
                    return "Ingrese mínimo 3 caracteres...";
                },
                searching: function () {
                    return "Buscando..";
                },
                noResults: function () {
                    return "No hay resultado";
                }
            },
            ajax: {
                url: this.url,
                dataType: "json",
                type: "GET",
                data: function (params) {
                    var queryParameters = {
                        q: params.term
                    };
                    return queryParameters;
                },
                processResults: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.name,
                                id: item.id
                            };
                        })
                    };
                }
            }
        });
        this.Events.call("OnInitSelect");
    };
    ;
    SelectHelper.prototype.initSelectAjaxNow = function () {
        console.log("initSelectAjaxNow");
        $(this.selectName).select2({
            allowClear: this.allowClear,
            placeholder: this.placeholder,
            theme: "bootstrap",
            tokenSeparators: [',', ''],
            language: {
                searching: function () {
                    return "Buscando..";
                },
                noResults: function () {
                    return "No hay resultado";
                }
            },
            ajax: {
                url: this.url,
                dataType: "json",
                type: "GET",
                data: this.data,
                processResults: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.name,
                                id: item.id
                            };
                        })
                    };
                }
            }
        });
        this.Events.call("OnInitSelect");
    };
    ;
    SelectHelper.prototype.getSelected = function () {
        return $(this.selectName).val();
    };
    SelectHelper.prototype.clearSelection = function () {
        $(this.selectName).val('').trigger('change');
    };
    return SelectHelper;
}());
