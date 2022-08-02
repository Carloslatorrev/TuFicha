using System.Web;
using System.Web.Optimization;

namespace TuFicha
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //homer
            // Homer style
            bundles.Add(new StyleBundle("~/bundles/homer/css").Include(
                      "~/Content/style.css", new CssRewriteUrlTransform()));


            bundles.Add(new StyleBundle("~/bundles/site/css").Include(
                      "~/Content/Site.css", new CssRewriteUrlTransform()));

            // Homer script
            bundles.Add(new ScriptBundle("~/bundles/homer/js").Include(
                      "~/Vendor/metisMenu/dist/metisMenu.min.js",
                      "~/Vendor/iCheck/icheck.min.js",
                      "~/Vendor/peity/jquery.peity.min.js",
                      "~/Vendor/sparkline/index.js",
                      "~/Scripts/homer.js",
                      "~/Scripts/charts.js",
                      "~/vendor/slimScroll/jquery.slimscroll.min.js"));

            //COMMON
            bundles.Add(new ScriptBundle("~/bundles/CommonHelpers").Include(
            "~/Scripts/app/CommonHelper.js",
            "~/Scripts/app/Helper_Alert.js",
            "~/Scripts/app/Helper_Events.js",
            "~/Scripts/app/Helper_Modal.js",
            "~/Scripts/app/Helper_Tables.js",
            "~/Scripts/app/Helper_Tree.js",
            "~/Scripts/app/Helper_Select2.js",
            "~/Scripts/app/Helper_TagsAdmin.js",
            "~/Scripts/app/Helper_Organigram.js"));

            bundles.Add(new ScriptBundle("~/bundles/MapsHelper").Include("~/Scripts/app/MapsHelper.js"));

            bundles.Add(new ScriptBundle("~/bundles/FileHelper").Include("~/Scripts/app/FilesHelper.js", "~/Scripts/jquery.form.min.js"));

            //aux
            //BUNDLES OBJETOS*******************************************************************************************************************************************


            //timeline
            bundles.Add(new StyleBundle("~/bundles/timeline/css").Include(
                       "~/Vendor/timeline/timeline.css"));

            // MaskNumber js
            bundles.Add(new ScriptBundle("~/bundles/MaskNumber/js").Include(
                      "~/Vendor/jquery.masknumber/jquery.masknumber.min.js"));

            //bootstrap File Input

            bundles.Add(new StyleBundle("~/bundles/Ifile/css").Include(
                       "~/Vendor/Ifile/Ifile.css"));
            bundles.Add(new ScriptBundle("~/bundles/Ifile/js").Include(
                      "~/Vendor/Ifile/Ifile.js"));

            // i-check style
            bundles.Add(new StyleBundle("~/bundles/icheck/css").Include(
                        "~/Vendor/iCheck/icheck.min.js", new CssRewriteUrlTransform()));

           

            // DualListBox CSS
            bundles.Add(new StyleBundle("~/bundles/DualListBox/css").Include(
                      "~/Vendor/dualListbox/bootstrap-duallistbox.min.css"));

            // DualListBox js
            bundles.Add(new ScriptBundle("~/bundles/DualListBox/js").Include(
                      "~/Vendor/dualListbox/jquery.bootstrap-duallistbox.js"));

            // Jasny css
            bundles.Add(new StyleBundle("~/bundles/Jasny/css").Include(
                      "~/Vendor/Jasny/jasny-bootstrap.min.css"));

            // Jasny js
            bundles.Add(new ScriptBundle("~/bundles/Jasny/js").Include(
                      "~/Scripts/jasny-bootstrap.min.js"));

            // Animate.css
            bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                "~/Vendor/animate.css/animate.min.css"));

            // Pe-icon-7-stroke
            bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css").Include(
                      "~/Icons/pe-icon-7-stroke/css/pe-icon-7-stroke.css", new CssRewriteUrlTransform()));

            // Font Awesome icons style
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                      "~/Vendor/fontawesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            // Bootstrap style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Vendor/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Vendor/bootstrap/dist/js/bootstrap.min.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                      "~/Vendor/jquery/dist/jquery.min.js"));

            // jQuery UI
            bundles.Add(new ScriptBundle("~/bundles/jqueryui/js").Include(
                      "~/Vendor/jquery-ui/jquery-ui.min.js"));

            // Flot chart
            bundles.Add(new ScriptBundle("~/bundles/flot/js").Include(
                      "~/Vendor/flot/jquery.flot.js",
                      "~/Vendor/flot/jquery.flot.tooltip.min.js",
                      "~/Vendor/flot/jquery.flot.resize.js",
                      "~/Vendor/flot/jquery.flot.pie.js",
                      "~/Vendor/flot.curvedlines/curvedLines.js",
                      "~/Vendor/jquery.flot.spline/index.js"));

            // Star rating
            bundles.Add(new ScriptBundle("~/bundles/starRating/js").Include(
                      "~/Vendor/bootstrap-star-rating/js/star-rating.min.js"));

            // Star rating style
            bundles.Add(new StyleBundle("~/bundles/starRating/css").Include(
                      "~/Vendor/bootstrap-star-rating/css/star-rating.min.css", new CssRewriteUrlTransform()));

            // Sweetalert
            bundles.Add(new ScriptBundle("~/bundles/sweetAlert/js").Include(
                      "~/Vendor/sweetalert/lib/sweet-alert.min.js"));

            // Sweetalert style
            bundles.Add(new StyleBundle("~/bundles/sweetAlert/css").Include(
                      "~/Vendor/sweetalert/lib/sweet-alert.css"));

            // Toastr
            bundles.Add(new ScriptBundle("~/bundles/toastr/js").Include(
                      "~/Vendor/toastr/build/toastr.min.js"));

            // Toastr style
            bundles.Add(new StyleBundle("~/bundles/toastr/css").Include(
                      "~/Vendor/toastr/build/toastr.min.css"));


            // jsTree
            bundles.Add(new ScriptBundle("~/bundles/jsTree/js").Include(
                      "~/Vendor/jsTree/jstree.min.js"));

            // jsTree styles
            bundles.Add(new StyleBundle("~/Vendor/jsTree/css").Include(
                      "~/Vendor/jsTree/style.css", new CssRewriteUrlTransform()));

            // Nestable
            bundles.Add(new ScriptBundle("~/bundles/nestable/js").Include(
                      "~/Vendor/nestable/jquery.nestable.js"));

            // Toastr
            bundles.Add(new ScriptBundle("~/bundles/bootstrapTour/js").Include(
                      "~/Vendor/bootstrap-tour/build/js/bootstrap-tour.min.js"));

            // Toastr style
            bundles.Add(new StyleBundle("~/bundles/bootstrapTour/css").Include(
                      "~/Vendor/bootstrap-tour/build/css/bootstrap-tour.min.css"));

            // Moment
            bundles.Add(new ScriptBundle("~/bundles/moment/js").Include(
                      "~/Vendor/moment/moment.js"));

            //// Full Calendar
            //bundles.Add(new ScriptBundle("~/bundles/fullCalendar/js").Include(
            //          "~/Vendor/fullcalendar/dist/fullcalendar.min.js"));

            //// Full Calendar style
            //bundles.Add(new StyleBundle("~/bundles/fullCalendar/css").Include(
            //          "~/Vendor/fullcalendar/dist/fullcalendar.min.css"));

            // Full Calendar V3.9.0
            bundles.Add(new ScriptBundle("~/bundles/fullCalendar/js").Include(
                      "~/Vendor/fullcalendar3.9.0/fullcalendar.js",
                      "~/Vendor/fullcalendar3.9.0/es.js"));

            // Full Calendar style
            bundles.Add(new StyleBundle("~/bundles/fullCalendar/css").Include(
                      "~/Vendor/fullcalendar3.9.0/fullcalendar.css"));

            // Chart JS
            bundles.Add(new ScriptBundle("~/bundles/chartjs/js").Include(
                      "~/Vendor/chartjs/Chart.min.js"));

            // Datatables
            bundles.Add(new ScriptBundle("~/bundles/datatables/js").Include(
                      "~/Vendor/datatables/media/js/jquery.dataTables.min.js"));

            // Datatables bootstrap
            bundles.Add(new ScriptBundle("~/bundles/datatablesBootstrap/js").Include(
                      "~/Vendor/datatables.net-bs/js/dataTables.bootstrap.min.js"));

            // Datatables plugins
            bundles.Add(new ScriptBundle("~/bundles/datatablesPlugins/js").Include(
                      "~/Vendor/pdfmake/build/pdfmake.min.js",
                      "~/Vendor/pdfmake/build/vfs_fonts.js",
                      "~/Vendor/datatables.net-buttons/js/buttons.html5.min.js",
                      "~/Vendor/datatables.net-buttons/js/buttons.print.min.js",
                      "~/Vendor/datatables.net-buttons/js/dataTables.buttons.min.js",
                      "~/Vendor/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"));


            // Datatables style
            bundles.Add(new StyleBundle("~/bundles/datatables/css").Include(
                      "~/Vendor/datatables.net-bs/css/dataTables.bootstrap.min.css"));

            // Datatables rowReorder
            bundles.Add(new ScriptBundle("~/bundles/datatablesrowReorder/js").Include(
                      "~/Vendor/datatables/media/js/dataTables.rowReorder.min.js"));
            // Datatables rowReorder style
            bundles.Add(new StyleBundle("~/bundles/datatablesrowReorder/css").Include(
                      "~/Vendor/datatables/media/css/rowReorder.dataTables.min.css"));

            // Xeditable
            bundles.Add(new ScriptBundle("~/bundles/xeditable/js").Include(
                      "~/Vendor/xeditable/bootstrap3-editable/js/bootstrap-editable.min.js"));

            // Xeditable style
            bundles.Add(new StyleBundle("~/bundles/xeditable/css").Include(
                      "~/Vendor/xeditable/bootstrap3-editable/css/bootstrap-editable.css", new CssRewriteUrlTransform()));

            // Select2 4.0.3
            bundles.Add(new ScriptBundle("~/bundles/select2/js").Include(
                      "~/Vendor/select2/select2.full.min.js", "~/Vendor/select2/i18n/es.js"));
            bundles.Add(new StyleBundle("~/bundles/select2/css").Include(
            "~/Vendor/select2/select2.min.css", "~/Vendor/select2/select2-4.0.3-bootstrap.min.css"));


            // Select 2 3.5.2
            //bundles.Add(new ScriptBundle("~/bundles/select2/js").Include(
            //		 "~/Vendor/select2-3.5.2/select2.min.js"));
            //bundles.Add(new StyleBundle("~/bundles/select2/css").Include(
            //	 "~/Vendor/select2-3.5.2/select2.css",
            //		 "~/Vendor/select2-bootstrap/select2-bootstrap.css"));

            // Touchspin
            bundles.Add(new ScriptBundle("~/bundles/touchspin/js").Include(
                     "~/Vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js"));

            // Touchspin style
            bundles.Add(new StyleBundle("~/bundles/touchspin/css").Include(
                      "~/Vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.css"));

            // Datepicker
            bundles.Add(new ScriptBundle("~/bundles/datepicker/js").Include(
                      "~/Vendor/bootstrap-datepicker-master/dist/js/bootstrap-datepicker.min.js",
                       "~/Vendor/bootstrap-datepicker-master/dist/locales/bootstrap-datepicker.es.min.js"));

            // Datepicker style
            bundles.Add(new StyleBundle("~/bundles/datepicker/css").Include(
                      "~/Vendor/bootstrap-datepicker-master/dist/css/bootstrap-datepicker3.min.css"));


            // Datepicker
            bundles.Add(new ScriptBundle("~/bundles/summernote/js").Include(
                      "~/Vendor/summernote/dist/summernote.min.js"));

            // Datepicker style
            bundles.Add(new StyleBundle("~/bundles/summernote/css").Include(
                      "~/Vendor/summernote/dist/summernote.css",
                      "~/Vendor/summernote/dist/summernote-bs3.css"));


            // Datepicker
            bundles.Add(new ScriptBundle("~/bundles/summernote2/js").Include(
                      "~/Vendor/summernote2/dist/summernote.min.js"));

            // Datepicker style
            bundles.Add(new StyleBundle("~/bundles/summernote2/css").Include(
                      "~/Vendor/summernote2/dist/summernote.css", new CssRewriteUrlTransform()));



            // Bootstrap checkbox style
            bundles.Add(new StyleBundle("~/bundles/bootstrapCheckbox/css").Include(
                      "~/Vendor/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            // Blueimp gallery
            bundles.Add(new ScriptBundle("~/bundles/blueimp/js").Include(
                      "~/Vendor/blueimp-gallery/js/jquery.blueimp-gallery.min.js"));

            // Blueimp gallery style
            bundles.Add(new StyleBundle("~/bundles/blueimp/css").Include(
                      "~/Vendor/blueimp-gallery/css/blueimp-gallery.min.css", new CssRewriteUrlTransform()));

            // Foo Table
            bundles.Add(new ScriptBundle("~/bundles/fooTable/js").Include(
                      "~/Vendor/fooTable/dist/footable.all.min.js"));

            // Foo Table style
            bundles.Add(new StyleBundle("~/bundles/fooTable/css").Include(
                      "~/Vendor/fooTable/css/footable.core.min.css", new CssRewriteUrlTransform()));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                      "~/Vendor/jquery-validation/jquery.validate.min.js"));

            // jQuery Unobtrusive
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                      "~/Vendor/jquery/dist/jquery.unobtrusive-ajax.js", "~/Vendor/jquery-validation/jquery.validate.unobtrusive.js"));

            // CodeMirror
            bundles.Add(new ScriptBundle("~/bundles/codemirror/js").Include(
                      "~/Vendor/codemirror/script/codemirror.js",
                      "~/Vendor/codemirror/javascript.js"));

            // CodeMirror style
            bundles.Add(new StyleBundle("~/bundles/codemirror/css").Include(
                      "~/Vendor/codemirror/style/codemirror.css"));

            // Chartist
            bundles.Add(new ScriptBundle("~/bundles/chartist/js").Include(
                      "~/Vendor/chartist/dist/chartist.min.js"));

            // Chartist style
            bundles.Add(new StyleBundle("~/bundles/chartist/css").Include(
                      "~/Vendor/chartist/custom/chartist.css"));

            // Ladda
            bundles.Add(new ScriptBundle("~/bundles/ladda/js").Include(
                      "~/Vendor/ladda/dist/spin.min.js",
                      "~/Vendor/ladda/dist/ladda.min.js",
                      "~/Vendor/ladda/dist/ladda.jquery.min.js"));

            // Ladda style
            bundles.Add(new StyleBundle("~/bundles/ladda/css").Include(
                      "~/Vendor/ladda/dist/ladda-themeless.min.css"));

            // Clockpicker
            bundles.Add(new ScriptBundle("~/bundles/clockpicker/js").Include(
                      "~/Vendor/clockpicker/dist/bootstrap-clockpicker.min.js"));

            // Clockpicker style
            bundles.Add(new StyleBundle("~/bundles/clockpicker/css").Include(
                      "~/Vendor/clockpicker/dist/bootstrap-clockpicker.min.css"));

            // DateTimePicker
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker/js").Include(
                      "~/Vendor/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"));

            // DateTimePicker style
            bundles.Add(new StyleBundle("~/bundles/datetimepicker/css").Include(
                      "~/Vendor/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css"));

            // D3
            bundles.Add(new ScriptBundle("~/bundles/d3/js").Include(
                      "~/Vendor/d3/d3.min.js"));

            // C3
            bundles.Add(new ScriptBundle("~/bundles/c3/js").Include(
                      "~/Vendor/c3/c3.min.js"));

            // C3 style
            bundles.Add(new StyleBundle("~/bundles/c3/css").Include(
                      "~/Vendor/c3/c3.min.css"));

            /*slick*/
            bundles.Add(new ScriptBundle("~/bundles/slick/js").Include(
                        "~/Vendor/Slick/slick.min.js"));
            bundles.Add(new StyleBundle("~/bundles/slick/css").Include(
                      "~/Vendor/Slick/slick.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/slickTheme/css").Include(
                      "~/Vendor/Slick/slick-theme.css", new CssRewriteUrlTransform()));


            /*SignalR*/
            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                        "~/Scripts/jquery.signalR-2.4.1.min.js"));

            // numeral 
            bundles.Add(new ScriptBundle("~/bundles/numeral").Include(
                        "~/Scripts/numeral.min.js"));

            // Rut
            bundles.Add(new ScriptBundle("~/bundles/rut").Include(
                        "~/Scripts/jquery.rut-master/jquery.rut.min.js"));


        }
    }
}
