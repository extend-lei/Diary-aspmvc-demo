using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
	public class DiaryEntry
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "请输入标题")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "标题应该在2-50个字符")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "请输入内容")] public string Content { get; set; } = string.Empty;
		[Required(ErrorMessage = "请输入时间")] public DateTime Created { get; set; } = DateTime.Now;
	}
}