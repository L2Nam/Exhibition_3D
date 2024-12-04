using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public static List<string> Question = new List<string>();
    public static List<int> QNo = new List<int>();
    public static List<string> QAns = new List<string>();
    public System.Random ran = new System.Random();

    void Start()
    {
        Question.Add("Ai đã vẽ The Last Supper trong khoảng thời gian ba năm từ 1495 đến 1498?\n A) Michaelangelo\n B) Raphael\n C) Leonardo da Vinci\n D) Picasso");
        QAns.Add("c");

        Question.Add("Họa sĩ nào đã vẽ bức 'The Night Watch'?\n A) Rubens\n B) Van Eyck\n C) Gainsborough\n D) Rembrandt");
        QAns.Add("d");

        Question.Add("Họa sĩ nào đã vẽ bức tranh 'The Persistence of Memory' đầy ám ảnh?\n A) Klee\n B) Van Eyck\n C) Duchamp\n D) Dali");
        QAns.Add("d");

        Question.Add("Họa sĩ nào trong số này không phải là người Ý?\n A) Pablo Picasso\n B) Leonardo da Vinci\n C) Titian\n D) Caravaggio");
        QAns.Add("a");

        Question.Add("Da Vinci được cho là đã vẽ Mona Lisa vào năm nào?\n A) 1403\n B) 1503\n C) 1703\n D) 1603");
        QAns.Add("b");

        Question.Add("Tranh của Salvador Dali thuộc trường phái hội họa nào?\n A) Siêu thực\n B) Chủ nghĩa hiện đại\n C) Chủ nghĩa hiện thực\n D) Ấn tượng");
        QAns.Add("a");

        Question.Add("Bức tranh 'The Last Supper' của Leonardo da Vinci được trưng bày ở đâu?\n A) Bảo tàng Louvre ở Paris, Pháp\n B) Santa Maria Delle Grazie ở Milan, Ý\n C) Phòng trưng bày Quốc gia ở London, Anh\n D) Bảo tàng Metropolitan ở thành phố New York");
        QAns.Add("b");

        Question.Add("Claude Monet là người sáng lập trường phái hội họa nào?\n A) Chủ nghĩa biểu hiện\n B) Chủ nghĩa lập thể\n C) Chủ nghĩa lãng mạn\n D) Ấn tượng");
        QAns.Add("d");

        Question.Add("Vincent van Gogh sinh năm nào?\n A) 1853\n B) 1863\n C) 1873\n D) 1883");
        QAns.Add("a");

        Question.Add("Van Gogh vẽ bức 'The Starry Night' trong hoàn cảnh nào?\n A) Khi đang ở nhà\n B) Khi ở bệnh viện tâm thần\n C) Khi đi du lịch\n D) Khi ở Paris");
        QAns.Add("b");

        Question.Add("Bức tranh nào là tác phẩm cuối cùng của Van Gogh trước khi qua đời?\n A) The Potato Eaters\n B) The Red Vineyard\n C) Wheatfield with Crows\n D) Cafe Terrace at Night");
        QAns.Add("c");

        Question.Add("Van Gogh đã tự cắt bộ phận nào của cơ thể trong một cơn khủng hoảng tinh thần?\n A) Ngón tay\n B) Tai\n C) Mũi\n D) Chân");
        QAns.Add("b");

        Question.Add("Bức tranh nào của Van Gogh từng trở thành một trong những bức tranh đắt giá nhất thế giới?\n A) The Starry Night\n B) Sunflowers\n C) Portrait of Dr. Gachet\n D) The Bedroom");
        QAns.Add("c");

        Question.Add("Van Gogh đã qua đời ở độ tuổi nào?\n A) 27\n B) 37\n C) 47\n D) 57");
        QAns.Add("b");

        Question.Add("Bức tranh 'The Starry Night' được vẽ tại thị trấn nào?\n A) Arles\n B) Saint Rémy\n C) Paris\n D) Amsterdam");
        QAns.Add("b");

        Question.Add("Leonardo da Vinci là một trong những họa sĩ nổi tiếng nhất của thời kỳ nào?\n A) Thời kỳ Phục hưng\n B) Thời kỳ Baroque\n C) Thời kỳ Cổ điển\n D) Thời kỳ Trung cổ");
        QAns.Add("a");

        Question.Add("Leonardo da Vinci đã vẽ 'The Vitruvian Man' để minh họa cho lý thuyết nào?\n A) Hình học\n B) Cân đối cơ thể người\n C) Vật lý\n D) Sinh học");
        QAns.Add("b");

        Question.Add("Pablo Picasso là người sáng lập trường phái hội họa nào?\n A) Chủ nghĩa lập thể\n B) Chủ nghĩa siêu thực\n C) Chủ nghĩa ấn tượng\n D) Chủ nghĩa biểu hiện");
        QAns.Add("a");

        Question.Add("Picasso vẽ bức tranh 'Guernica' vào năm nào để phản đối cuộc không kích của Đức vào một thành phố Tây Ban Nha?\n A) 1937\n B) 1947\n C) 1927\n D) 1917");
        QAns.Add("a");

        Question.Add("Pablo Picasso là họa sĩ người nước nào?\n A) Pháp\n B) Ý\n C) Tây Ban Nha\n D) Bồ Đào Nha");
        QAns.Add("c");

        Question.Add("Bức tranh nào của Picasso được coi là biểu tượng của chủ nghĩa lập thể?\n A) Guernica\n B) Les Demoiselles d'Avignon\n C) The Old Guitarist\n D) The Weeping Woman");
        QAns.Add("b");

        Question.Add("Picasso đã qua đời vào năm nào?\n A) 1971\n B) 1973\n C) 1981\n D) 1993");
        QAns.Add("b");

        Question.Add("Trong suốt cuộc đời, Picasso đã vẽ khoảng bao nhiêu bức tranh?\n A) 1000\n B) 2000\n C) 5000\n D) 10000");
        QAns.Add("c");

        Question.Add("Tranh Đông Hồ chủ yếu miêu tả những gì?\n A) Phong cảnh thiên nhiên\n B) Chân dung các nhân vật nổi tiếng\n C) Cảnh sinh hoạt, đời sống và tín ngưỡng dân gian\n D) Chiến tranh và lịch sử");
        QAns.Add("c");

        Question.Add("Tranh Đông Hồ có đặc điểm gì nổi bật?\n A) Sử dụng màu sắc tươi sáng và hình ảnh sinh động\n B) Vẽ theo phong cách hiện đại\n C) Chủ yếu dùng màu tối và tối giản\n D) Có những chi tiết siêu thực");
        QAns.Add("a");

        Question.Add("Bức tranh 'Bác Hồ ở chiến khu Việt Bắc' của họa sĩ Dương Bích Liên được vẽ vào năm nào?\n A) 1988\n B) 1950\n C) 1975\n D) 1980");
        QAns.Add("d");

        Question.Add("Bức tranh 'Người bán gạo' (La marchand de riz) của họa sĩ Nguyễn Phan Chánh được sáng tác vào năm nào?\n A) 1932\n B) 1940\n C) 1930\n D) 1925");
        QAns.Add("a");

        Question.Add("Bức tranh 'Bình minh trên nông trang' của họa sĩ Nguyễn Đức Nùng được vẽ vào năm nào?\n A) 1958\n B) 1960\n C) 1965\n D) 1970");
        QAns.Add("a");

        Question.Add("Bức tranh 'Phố cổ' của họa sĩ Bùi Xuân Phái miêu tả cảnh vật gì?\n A) Cảnh phố cổ Hà Nội\n B) Cảnh phố Sài Gòn\n C) Phố cổ Hội An\n D) Phố Hà Nội thời hiện đại");
        QAns.Add("a");

        for (int j = 0; j < Question.Count; j++)
        {
            QNo.Add(j);
        }
        
    }

    void Update()
    {
        
    }
}
