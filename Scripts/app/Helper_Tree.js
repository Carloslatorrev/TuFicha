var TreeHelper = (function () {
    function TreeHelper(_treeName) {
        this.treeName = _treeName;
        this.Events = new EventsHelper();
        this.expandBtnName = '#btnExpand';
        this.collapseBtnName = '#btnCollapse';
        this.searchInputName = '#treesearch';
    }
    TreeHelper.prototype.initTree = function () {
        var _this = this;
        $(this.treeName).jstree({
            'core': {
                "check_callback": function (op, node, par, pos, more) {
                    if (("#dataValidateNode").length) {
                        if (node.data.type != "ro" && par.parent != null && !node.data.type.includes("-des") && !par.data.type.includes("-des")) {
                            var Validate = $("#dataValidateNode").val().split(";");
                            for (var i = 0; i < Validate.length; i++) {
                                var JerarquiaValidate = Validate[i].split("|");
                                if (JerarquiaValidate[0] == node.data.IdNivelJerarquico) {
                                    if (JerarquiaValidate[1].split("-").includes(par.data.type)) {
                                        if (node.parent != par.id && more.core != undefined) {
                                            _this.Events.call("NodeMoveBd", { node: node, par: par, pos: pos });
                                        }
                                        else if (more.core != undefined) {
                                            _this.Events.call("NodeUpdateIndiceBd", { node: node, par: par, pos: pos });
                                        }
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    return false;
                },
                'data': []
            },
            'search': {
                'case_insensitive': false,
                'show_only_matches': true
            },
            'plugins': ["search", "sort", "dnd", "state"],
            "sort": function (a, b) {
            }
        });
        if (this.Events.on("OnSelectNode")) {
            $(this.treeName).on("select_node.jstree", function (evt, data) {
                _this.nodeData = data.node;
                _this.Events.call("OnSelectNode", data.node);
            });
        }
        var to = false;
        $(this.searchInputName).keyup(function () {
            if (to) {
                clearTimeout(to);
            }
            to = setTimeout(function () {
                var v = $(_this.searchInputName).val();
                $(_this.treeName).jstree(true).search(v);
            }, 500);
        });
        $(this.collapseBtnName).click(function () {
            $(_this.treeName).jstree('close_all');
        });
        $(this.expandBtnName).click(function () {
            $(_this.treeName).jstree('open_all');
        });
        this.Events.call("OnInitTree");
    };
    TreeHelper.prototype.updateTreeData = function (_urlGetTree, _params) {
        var _this = this;
        if (_params === void 0) { _params = {}; }
        $.ajax({
            url: _urlGetTree,
            data: _params,
            async: true,
            type: 'GET',
            beforeSend: function () {
                $(".panel-load").addClass("sk-loading");
            },
            success: function (result) {
                var lstNodes = JSON.parse(result);
                $(_this.treeName).jstree(true).settings.core.data = lstNodes;
                $(_this.treeName).jstree(true).refresh();
                _this.Events.call("OnGetTreeData");
                $(".panel-load").removeClass("sk-loading");
            },
            error: function (xhr, status, error) {
                var alert = new AlertHelper();
                alert.toastErrorData(xhr.responseText);
            }
        });
    };
    return TreeHelper;
}());
var SearchTreeHelper = (function () {
    function SearchTreeHelper(_treeName, _expandBtnName, _collapseBtnName, _searchInputName) {
        this.Events = new EventsHelper();
        this.treeName = _treeName;
        this.expandBtnName = _expandBtnName;
        this.collapseBtnName = _collapseBtnName;
        this.searchInputName = _searchInputName;
    }
    SearchTreeHelper.prototype.initTree = function () {
        var _this = this;
        $(this.treeName).jstree({
            'search': {
                'case_insensitive': false,
                'show_only_matches': true
            },
            'plugins': ["search", "sort", "state"],
        });
        if (this.Events.on("OnSelectNode")) {
            $(this.treeName).on("select_node.jstree", function (evt, data) {
                _this.nodeData = data.node;
                _this.Events.call("OnSelectNode", data.node);
            });
        }
        var to = false;
        $(this.searchInputName).keyup(function () {
            if (to) {
                clearTimeout(to);
            }
            to = setTimeout(function () {
                var v = $(_this.searchInputName).val();
                $(_this.treeName).jstree(true).search(v);
            }, 500);
        });
        $(this.collapseBtnName).click(function () {
            $(_this.treeName).jstree('close_all');
        });
        $(this.expandBtnName).click(function () {
            $(_this.treeName).jstree('open_all');
        });
    };
    SearchTreeHelper.prototype.updateTreeData = function (_urlGetTree, _data) {
        var _this = this;
        $.ajax({
            url: _urlGetTree,
            data: _data,
            type: 'GET',
            success: function (result) {
                var lstNodes = JSON.parse(result);
                $(_this.treeName).jstree(true).settings.core.data = lstNodes;
                $(_this.treeName).jstree(true).refresh();
                _this.Events.call("OnGetTreeData");
            },
            error: function (xhr, status, error) {
                var alert = new AlertHelper();
                alert.toastErrorData(xhr.responseText);
            }
        });
    };
    return SearchTreeHelper;
}());
