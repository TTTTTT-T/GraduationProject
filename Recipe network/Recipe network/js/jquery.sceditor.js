/*----------------------------------------------------*/
/*  SCEditor
/*----------------------------------------------------*/

(function($){
	$(document).ready(function(){
		$(".WYSIWYG").sceditor({
			plugins: "bbcode",
			toolbar: "bold,italic,underline,center,right,justify,font,size,color,removeformat,bulletlist,orderedlist,table,quote,image,link,ltr,rtl,source",
			width: "100%"
		});

		function addIng() {
			var newElem = $('tr.ingredients-cont.ing1:first').clone();
			newElem.find('input').val('');
			newElem.appendTo('table#ingredients-sort1');
		}
		function addIng1() {
			var newElem = $('tr.ingredients-cont.ing2:first').clone();
			newElem.find('input').val('');
			newElem.appendTo('table#ingredients-sort2');
		}


		//sortable table
		var fixHelper =  function(e, tr) {
		    var $originals = tr.children();
		    var $helper = tr.clone();
		    $helper.children().each(function(index)
		    {
		      // Set helper cell sizes to match the original sizes
		      $(this).width($originals.eq(index).width());
		    });
		    return $helper;
		  };
		if ($("table#ingredients-sort2").is('*')) {
			$('.add_ingredient').click(function (e) {
				e.preventDefault();
				addIng();
			});
			$('.add_ingredient2').click(function (e) {
				e.preventDefault();
				addIng1();
			});
			
			// remove ingredient
			$('#ingredients-sort1 .delete').live('click',function(e){
				e.preventDefault();
				$(this).parent().parent().remove();
			});
			$('#ingredients-sort2 .delete').live('click', function (e) {
				e.preventDefault();
				$(this).parent().parent().remove();
			});
			$('table#ingredients-sort tbody').sortable({
				forcePlaceholderSize: true,
				forceHelperSize: true,
				placeholder : 'sortableHelper',
				helper: fixHelper,
				zIndex: 999990,
				opacity: 0.6,
				tolerance: "pointer"
			})
	 	}

	});
})(this.jQuery);