/*----------------------------------------------------*/
/*  SCEditor
/*----------------------------------------------------*/

(function ($) {
	$(document).ready(function () {
		$(".WYSIWYG").sceditor({
			plugins: "bbcode",
			toolbar: "bold,italic,underline,center,right,justify,font,size,color,removeformat,bulletlist,orderedlist,table,quote,image,link,ltr,rtl,source",
			width: "100%"
		});

			$('.add_separator').click(function (e) {
				e.preventDefault();
				var newElem = $('<tr class="ingredients-cont separator"><td class="icon"><i class="fa fa-arrows"></i></td><td><input name="ingredient" type="text" class="ingredient" placeholder="" /></td><td><input name="ingredient" type="bu " class="notes" placeholder="Separator" value="," /></td><td class="action"><a title="Delete" class="delete" href="#"><i class="fa fa-remove"></i></a></td></tr>');
				newElem.appendTo('table#ingredients-sort1');
			})
			// remove ingredient
			$('#ingredients-sort1 .delete').live('click', function (e) {
				e.preventDefault();
				$(this).parent().parent().remove();
			});

			$('table#ingredients-sort1 tbody').sortable({
				forcePlaceholderSize: true,
				forceHelperSize: true,
				placeholder: 'sortableHelper',
				helper: fixHelper,
				zIndex: 999990,
				opacity: 0.6,
				tolerance: "pointer"
			})
		}

	});
})(this.jQuery);