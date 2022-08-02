var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var GenericController = (function () {
    function GenericController() {
        this.alert = new AlertHelper();
        this.Events = new EventsHelper();
        $(document).ajaxError(function (e, xhr) {
            var pathname = window.location.pathname;
            if (xhr.status == 403) {
                window.location.href = window.location.protocol + "//" + window.location.host + "/account/LogOff/";
            }
            if (xhr.status == 401) {
                window.location.href = window.location.protocol + "//" + window.location.host + "/account/LogOff/";
            }
        });
    }
    GenericController.prototype.getAppendPartial = function (_modalCanvas, _url, _data) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'GET',
            data: _data,
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                $(".panel-load").removeClass("sk-loading");
                $(_modalCanvas).append(result);
                _this.Events.call("OnGetAppendPartial");
            }
        });
    };
    GenericController.prototype.getSelectListItem = function (_select2, _url, _data) {
        $.ajax({
            type: 'GET',
            url: _url,
            data: _data
        }).then(function (data) {
            $(_select2).empty().trigger("change");
            console.log(data);
            for (var index = 0; index < data.length; index++) {
                var element = data[index];
                var option = new Option(element.Text, element.Value, true, true);
                $(_select2).append(option).trigger('change');
            }
        });
    };
    GenericController.prototype.getAndInsertDataOnObj = function (obj, _url, _data) {
        $.ajax({
            url: _url,
            type: 'GET',
            data: _data,
            async: false,
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                $(".panel-load").removeClass("sk-loading");
                $(obj).val(result);
            }
        });
    };
    GenericController.prototype.getPartialContentTypeJson = function (_panelName, _url, _data, FireEvent) {
        var _this = this;
        if (FireEvent === void 0) { FireEvent = true; }
        $.ajax({
            url: _url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(_data),
            async: false,
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                $(".panel-load").removeClass("sk-loading");
                $(_panelName).html(result);
                if (FireEvent) {
                    _this.Events.call("OnGetPartial");
                }
            }
        });
    };
    GenericController.prototype.getPartial = function (_panelName, _url, _data, FireEvent) {
        var _this = this;
        if (FireEvent === void 0) { FireEvent = true; }
        $.ajax({
            url: _url,
            type: 'GET',
            data: _data,
            async: false,
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                $(".panel-load").removeClass("sk-loading");
                $(_panelName).html(result);
                if (FireEvent) {
                    _this.Events.call("OnGetPartial");
                }
            }
        });
    };
    GenericController.prototype.getPartialCustomEvent = function (_panelName, _url, _data, _Event) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'GET',
            data: _data,
            async: false,
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                $(".panel-load").removeClass("sk-loading");
                $(_panelName).html(result);
                _this.Events.call(_Event);
            }
        });
    };
    GenericController.prototype.getPartialAsync = function (_panelName, _url, _data) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'GET',
            data: _data,
            async: true,
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                $(".panel-load").removeClass("sk-loading");
                $(_panelName).html(result);
                _this.Events.call("OnGetPartial");
            }
        });
    };
    GenericController.prototype.postForm = function (form, _url) {
        var _this = this;
        var postData = form.serialize();
        $.post(_url, postData, function (response) {
            _this.Events.call("OnPostForm", response);
        });
    };
    GenericController.prototype.postFormData = function (data, _url) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'POST',
            data: data,
            contentType: false,
            processData: false,
            success: function (result) {
                _this.Events.call("OnPostFormData", result);
            }
        });
    };
    GenericController.prototype.postDataSimple = function (_data, _url) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'POST',
            data: _data,
            success: function (result) {
                if (result == "true") {
                    _this.Events.call("OnPostDataSimple", result);
                }
                else {
                    _this.alert.toastErrorData(result);
                }
            }
        });
    };
    GenericController.prototype.postCustomData = function (data, _url) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                _this.Events.call("OnPostCustomData", result);
                $(".panel-load").removeClass("sk-loading");
            }
        });
    };
    GenericController.prototype.postCustomDataAsync = function (data, _url) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'POST',
            async: true,
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (result) {
                _this.Events.call("OnPostCustomData", result);
            }
        });
    };
    GenericController.prototype.postFileToDB = function (file, _url) {
        var _this = this;
        $.ajax({
            url: _url,
            type: 'POST',
            data: file,
            contentType: false,
            processData: false,
            beforeSend: function () {
                _this.Events.call('OnIniSaveFile');
            },
            success: function (result) {
                _this.Events.call('OnSuccessSaveFile', result);
            }, complete: function (result) {
                _this.Events.call('OnCompleteSaveFileaveFile', result);
            }
        });
    };
    GenericController.prototype.hideLink = function (name) {
        $(name).addClass("hide");
        $(name).attr("href", "#");
    };
    GenericController.prototype.showLink = function (name) {
        $(name).removeClass("hide");
    };
    GenericController.prototype.disableLink = function (name) {
        $(name).addClass("disabled");
        $(name).attr("href", "#");
    };
    GenericController.prototype.enableLink = function (name) {
        $(name).removeClass("disabled");
    };
    GenericController.prototype.setLink = function (name, link) {
        $(name).attr("href", link);
    };
    GenericController.prototype.updateTreeMenu = function (estado, clase) {
        var _this = this;
        $("." + clase).each(function (i, obj) {
            var showON = $(obj).data("showon").split("-");
            var hide = Boolean($(obj).data("hide"));
            var id = $(obj).prop('id');
            var isOFF = true;
            $(showON).each(function (index, item) {
                if (String(item) == estado) {
                    isOFF = false;
                    if (hide) {
                        _this.showLink("#" + id);
                    }
                    else {
                        _this.enableLink("#" + id);
                    }
                }
            });
            if (isOFF) {
                if (hide) {
                    _this.hideLink("#" + id);
                }
                else {
                    _this.disableLink("#" + id);
                }
            }
        });
    };
    return GenericController;
}());
var GenericSelectFaena = (function (_super) {
    __extends(GenericSelectFaena, _super);
    function GenericSelectFaena(_InputName, _LabelName) {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectTree";
        _this.treeName = "#treeSelectFaena";
        _this.urlGetTree = "/Admin/Faenas/getTree";
        _this.urlGetModal = "/Admin/Faenas/getSelFaena";
        _this.InputName = _InputName;
        _this.LabelName = _LabelName;
        _this.modal = new ModalHelper(_this.modalName);
        return _this;
    }
    GenericSelectFaena.prototype.seleccionarFaena = function (_input, _label) {
        this.getModal({}, { InputName: this.InputName, LabelName: this.LabelName });
    };
    GenericSelectFaena.prototype.deleteFaena = function () {
        $(this.InputName).val(null);
        $(this.LabelName).val('-');
    };
    GenericSelectFaena.prototype.initSearchTree = function (_params) {
        var _this = this;
        this.searchTree = new SearchTreeHelper(this.treeName, "#btnExpSearch_Faena", "#btnColSearch_Faena", "#txtSearch_Faena");
        this.searchTree.Events.bind("OnSelectNode", function (node) {
            var tipo = node.data.type;
            var parents = node.parents;
            var rootNodeId = node.data.db_id;
            if (tipo == "ua" || tipo == 'ro') {
                $("#btnSelectFaena").prop("disabled", true);
                _this.nodeSearchID = null;
                _this.nodeSearchName = '-';
            }
            else {
                $("#btnSelectFaena").prop("disabled", false);
                _this.nodeSearchID = node.data.db_id;
                _this.nodeSearchName = node.text;
            }
            $(_this.InputName).val(_this.nodeSearchID);
            $(_this.LabelName).val(_this.nodeSearchName);
        });
        this.searchTree.initTree();
        this.searchTree.updateTreeData(this.urlGetTree, _params);
    };
    ;
    GenericSelectFaena.prototype.getModal = function (_paramsTree, _paramsModal) {
        var _this = this;
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.initSearchTree(_paramsTree);
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, _paramsModal);
    };
    return GenericSelectFaena;
}(GenericController));
var GenericSelectUnidadJerarquica = (function (_super) {
    __extends(GenericSelectUnidadJerarquica, _super);
    function GenericSelectUnidadJerarquica(_InputName, _LabelName) {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectTree";
        _this.treeName = "#treeSelectJerarquia";
        _this.urlGetTree = "/PER/Jerarquia/getSelectTree";
        _this.urlGetModal = "/PER/Jerarquia/getSelJerarquia";
        _this.modal = new ModalHelper(_this.modalName);
        _this.InputName = _InputName;
        _this.LabelName = _LabelName;
        return _this;
    }
    GenericSelectUnidadJerarquica.prototype.seleccionarUnidad = function (_input, _label) {
        this.getModal({}, { InputName: this.InputName, LabelName: this.LabelName });
    };
    GenericSelectUnidadJerarquica.prototype.deleteUnidad = function () {
        $(this.InputName).val(null);
        $(this.LabelName).val('-');
    };
    GenericSelectUnidadJerarquica.prototype.initSearchTree = function (_params) {
        var _this = this;
        this.searchTree = new SearchTreeHelper(this.treeName, "#btnExpSearch_Jer", "#btnColSearch_Jer", "#txtSearch_Jer");
        this.searchTree.Events.bind("OnSelectNode", function (node) {
            var tipo = node.data.type;
            var parents = node.parents;
            var rootNodeId = node.data.db_id;
            if (tipo == "ua" || tipo == 'ro') {
                $("#btnSelectFaena").prop("disabled", true);
                _this.nodeSearchID = null;
            }
            else {
                $("#btnSelectFaena").prop("disabled", false);
                _this.nodeSearchID = node.data.db_id;
                _this.nodeSearchName = node.text;
                for (var i = 0; i < parents.length; i++) {
                    if (parents[i] != "#") {
                        var n = $(_this.treeName).jstree(true).get_node(parents[i]);
                        if (n["data"].type == "fa") {
                            _this.nodeSearchName = n.text + "/" + node.text;
                            break;
                        }
                        ;
                    }
                }
            }
            $(_this.InputName).val(_this.nodeSearchID);
            $(_this.LabelName).val(_this.nodeSearchName);
        });
        this.searchTree.initTree();
        this.searchTree.updateTreeData(this.urlGetTree, _params);
    };
    ;
    GenericSelectUnidadJerarquica.prototype.getModal = function (_paramsTree, _paramsModal) {
        var _this = this;
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.initSearchTree(_paramsTree);
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, _paramsModal);
    };
    return GenericSelectUnidadJerarquica;
}(GenericController));
var GenericSelectJerarquia = (function (_super) {
    __extends(GenericSelectJerarquia, _super);
    function GenericSelectJerarquia() {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectTree";
        _this.treeName = "#treeSelectJerarquia";
        _this.urlGetTree = "/PER/Jerarquia/getSelectTree";
        _this.urlGetModal = "/PER/Jerarquia/getSelJerarquia";
        _this.modal = new ModalHelper(_this.modalName);
        return _this;
    }
    GenericSelectJerarquia.prototype.initSearchTree = function (_params) {
        var _this = this;
        this.searchTree = new SearchTreeHelper(this.treeName, "#btnExpSearch_Jer", "#btnColSearch_Jer", "#txtSearch_Jer");
        this.searchTree.Events.bind("OnSelectNode", function (node) {
            var tipo = node.data.type;
            var parents = node.parents;
            var rootNodeId = node.data.db_id;
            if (tipo == "ua" || tipo == 'ro') {
                $("#btnSelectFaena").prop("disabled", true);
                _this.nodeSearchID = null;
            }
            else {
                $("#btnSelectFaena").prop("disabled", false);
                _this.nodeSearchID = node.data.db_id;
                _this.nodeSearchName = node.text;
                for (var i = 0; i < parents.length; i++) {
                    if (parents[i] != "#") {
                        var n = $(_this.treeName).jstree(true).get_node(parents[i]);
                        if (n["data"].type == "fa") {
                            _this.nodeSearchName = n.text + "/" + node.text;
                            break;
                        }
                        ;
                    }
                }
            }
        });
        this.searchTree.initTree();
        if (_params != "0") {
            this.searchTree.Events.bind("OnGetTreeData", function () {
                var NodoSelecionado = "t_" + _params;
                setTimeout(function () { $('#treeSelectJerarquia').jstree(true).select_node(NodoSelecionado); }, 300);
            });
        }
        this.searchTree.updateTreeData(this.urlGetTree, _params);
    };
    ;
    GenericSelectJerarquia.prototype.getModal = function (_paramsTree, _paramsModal) {
        var _this = this;
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.initSearchTree(_paramsTree);
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, _paramsModal);
    };
    return GenericSelectJerarquia;
}(GenericController));
var GenericSelectMarcaModelo = (function (_super) {
    __extends(GenericSelectMarcaModelo, _super);
    function GenericSelectMarcaModelo(_InputName, _LabelName) {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectTree";
        _this.treeName = "#treeSelectMarcaModelo";
        _this.urlGetTree = "/Admin/MarcaModelo/getSelectTree";
        _this.urlGetModal = "/Admin/MarcaModelo/getSelMarcaModelo";
        _this.InputName = _InputName;
        _this.LabelName = _LabelName;
        _this.OriginalInputVal = $(_this.InputName).val();
        _this.OriginalLabelVal = $(_this.LabelName).val();
        _this.modal = new ModalHelper(_this.modalName);
        return _this;
    }
    GenericSelectMarcaModelo.prototype.seleccionarModelo = function (_input, _label) {
        this.getModal({}, { InputName: this.InputName, LabelName: this.LabelName });
    };
    GenericSelectMarcaModelo.prototype.deleteModelo = function () {
        $(this.InputName).val(this.OriginalInputVal);
        $(this.LabelName).val(this.OriginalLabelVal);
    };
    GenericSelectMarcaModelo.prototype.selectModel = function () {
        $(this.InputName).val(this.TemporalInputVal);
        $(this.LabelName).val(this.TemporalLabelVal);
    };
    GenericSelectMarcaModelo.prototype.initSearchTree = function (_params) {
        var _this = this;
        this.searchTree = new SearchTreeHelper(this.treeName, "#btnExpSearch_Model", "#btnColSearch_Model", "#txtSearch_Model");
        this.searchTree.Events.bind("OnSelectNode", function (node) {
            var tipo = node.data.type;
            var parents = node.parents;
            var rootNodeId = node.data.db_id;
            if (tipo == "ua" || tipo == 'ro' || tipo == 'ma') {
                $("#btnSelectMarcaModelo").prop("disabled", true);
                _this.nodeSearchID = null;
            }
            else {
                $("#btnSelectMarcaModelo").prop("disabled", false);
                _this.nodeSearchID = node.data.db_id;
                _this.nodeSearchName = node.text;
                for (var i = 0; i < parents.length; i++) {
                    if (parents[i] != "#") {
                        var n = $(_this.treeName).jstree(true).get_node(parents[i]);
                        if (n["data"].type == "ma") {
                            _this.nodeSearchName = n.text + "/" + node.text;
                            break;
                        }
                        ;
                    }
                }
            }
            _this.TemporalInputVal = _this.nodeSearchID;
            _this.TemporalLabelVal = _this.nodeSearchName;
        });
        this.searchTree.initTree();
        this.searchTree.updateTreeData(this.urlGetTree, _params);
    };
    ;
    GenericSelectMarcaModelo.prototype.getModal = function (_paramsTree, _paramsModal) {
        var _this = this;
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.initSearchTree(_paramsTree);
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, _paramsModal);
    };
    return GenericSelectMarcaModelo;
}(GenericController));
var GenericSelectClaseActivo = (function (_super) {
    __extends(GenericSelectClaseActivo, _super);
    function GenericSelectClaseActivo(_InputName, _LabelName) {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectTree";
        _this.treeName = "#treeSelectClase";
        _this.urlGetTree = "/GAE/Clase/getTree";
        _this.urlGetModal = "/GAE/Clase/getSelClase";
        _this.InputName = _InputName;
        _this.LabelName = _LabelName;
        _this.OriginalInputVal = $(_this.InputName).val();
        _this.OriginalLabelVal = $(_this.LabelName).val();
        _this.modal = new ModalHelper(_this.modalName);
        return _this;
    }
    GenericSelectClaseActivo.prototype.seleccionarClase = function (_input, _label) {
        this.getModal({}, { InputName: this.InputName, LabelName: this.LabelName });
    };
    GenericSelectClaseActivo.prototype.deleteClase = function () {
        $(this.InputName).val(this.OriginalInputVal);
        $(this.LabelName).val(this.OriginalLabelVal);
    };
    GenericSelectClaseActivo.prototype.selectClase = function () {
        $(this.InputName).val(this.TemporalInputVal);
        $(this.LabelName).val(this.TemporalLabelVal);
    };
    GenericSelectClaseActivo.prototype.initSearchTree = function (_params) {
        var _this = this;
        this.searchTree = new SearchTreeHelper(this.treeName, "#btnExpSearch_Clase", "#btnColSearch_Clase", "#txtSearch_Clase");
        this.searchTree.Events.bind("OnSelectNode", function (node) {
            var tipo = node.data.type;
            var parents = node.parents;
            var rootNodeId = node.data.db_id;
            if (tipo == "ua" || tipo == 'ro') {
                $("#btnSelectClase").prop("disabled", true);
                _this.nodeSearchID = null;
            }
            else {
                $("#btnSelectClase").prop("disabled", false);
                _this.nodeSearchID = node.data.db_id;
                _this.nodeSearchName = node.text;
                for (var i = 0; i < parents.length; i++) {
                    if (parents[i] != "#") {
                        var n = $(_this.treeName).jstree(true).get_node(parents[i]);
                        if (n["data"].type == "clase") {
                            _this.nodeSearchName = n.text + "/" + node.text;
                            break;
                        }
                        ;
                    }
                }
            }
            _this.TemporalInputVal = _this.nodeSearchID;
            _this.TemporalLabelVal = _this.nodeSearchName;
        });
        this.searchTree.initTree();
        this.searchTree.updateTreeData(this.urlGetTree, _params);
    };
    ;
    GenericSelectClaseActivo.prototype.getModal = function (_paramsTree, _paramsModal) {
        var _this = this;
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.initSearchTree(_paramsTree);
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, { InputName: this.InputName, LabelName: this.LabelName });
    };
    return GenericSelectClaseActivo;
}(GenericController));
var GenericSelectIcono = (function (_super) {
    __extends(GenericSelectIcono, _super);
    function GenericSelectIcono() {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectIcono";
        _this.urlGetModal = "/Intranet/Configuraciones/getSelIcono";
        _this.modal = new ModalHelper(_this.modalName);
        return _this;
    }
    GenericSelectIcono.prototype.getModal = function (_paramsModal) {
        var _this = this;
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, _paramsModal);
    };
    GenericSelectIcono.prototype.icono = function (e) {
        $(".icono-div").removeClass("icono-div-active");
        e.parent("div").addClass("icono-div-active");
        var clase = e.children("i").attr("class");
        $("#btnSelectIcono").prop("disabled", false).data('clase', clase);
    };
    GenericSelectIcono.prototype.seleccionar = function (e) {
        var indice = $("#indiceInput").val();
        var clase = e.data('clase');
        $("input[name='BotonIcono'][data-indice-input='" + indice + "']").val(clase).trigger("change");
        ;
        this.modal.close();
    };
    return GenericSelectIcono;
}(GenericController));
var GenericSelectCarpetasDoc = (function (_super) {
    __extends(GenericSelectCarpetasDoc, _super);
    function GenericSelectCarpetasDoc(_InputName, _LabelName, _TipoObject) {
        var _this = _super.call(this) || this;
        _this.modalCanvas = "#modalCanvas";
        _this.modalName = "#modalSelectTree";
        _this.treeName = "#treeSelectCarpetasDoc";
        _this.urlGetTree = "/Admin/Paths/getTreeCarpetasDoc";
        _this.urlGetModal = "/Admin/Paths/getSelCarpetasDoc";
        _this.InputName = _InputName;
        _this.LabelName = _LabelName;
        _this.TipoObject = _TipoObject;
        _this.modal = new ModalHelper(_this.modalName);
        return _this;
    }
    GenericSelectCarpetasDoc.prototype.seleccionarCarpetasDoc = function () {
        this.getModal({}, { InputName: this.InputName, LabelName: this.LabelName });
    };
    GenericSelectCarpetasDoc.prototype.deleteCarpetasDoc = function () {
        $(this.InputName).val(null);
        $(this.LabelName).val('-');
    };
    GenericSelectCarpetasDoc.prototype.initSearchTree = function (_params) {
        var _this = this;
        this.searchTree = new SearchTreeHelper(this.treeName, "#btnExpSearch_CarpetasDoc", "#btnConSearch_CarpetasDoc", "#treeSelectCarpetasDoc");
        this.searchTree.Events.bind("OnSelectNode", function (node) {
            var tipo = node.data.type;
            var parents = node.parents;
            var rootNodeId = node.data.db_id;
            if (tipo == 'ro' || tipo == 'ti') {
                $("#btnSelectCarpetasDoc").prop("disabled", true);
                _this.nodeSearchID = null;
                _this.nodeSearchName = '-';
            }
            else {
                $("#btnSelectCarpetasDoc").prop("disabled", false);
                _this.nodeSearchID = node.data.db_id;
                _this.nodeSearchName = node.text;
                for (var i = 0; i < parents.length; i++) {
                    if (parents[i] != "#") {
                        var n = $(_this.treeName).jstree(true).get_node(parents[i]);
                        if (n["data"].type == "fa") {
                            _this.nodeSearchName = n.text + "/" + node.text;
                            break;
                        }
                        ;
                    }
                }
            }
            $(_this.InputName).val(_this.nodeSearchID);
            $(_this.LabelName).val(_this.nodeSearchName);
        });
        this.searchTree.initTree();
        this.searchTree.updateTreeData(this.urlGetTree, _params);
        console.log("entro");
    };
    ;
    GenericSelectCarpetasDoc.prototype.getModal = function (_paramsTree, _paramsModal) {
        var _this = this;
        _paramsTree = { TipoObject: this.TipoObject };
        this.modal.Events.bind("OnGetModal", function () {
            _this.modal.initModal();
            _this.initSearchTree(_paramsTree);
            _this.modal.open();
        });
        this.modal.getModal(this.modalCanvas, this.urlGetModal, _paramsModal);
    };
    return GenericSelectCarpetasDoc;
}(GenericController));
