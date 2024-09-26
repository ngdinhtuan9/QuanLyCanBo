using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTrinhDo.Entity
{
    public class Trainee
    {
        public string Ma { get; set; }  // Mã
        public string HoTen { get; set; }  // Họ tên
        public DateTime NgaySinh { get; set; }  // Ngày sinh
        public string QueQuan { get; set; }  // Quê quán
        public string SoCCCD { get; set; }  // Số CCCD
        public DateTime NgayCap { get; set; }  // Ngày cấp
        public string NoiCap { get; set; }  // Nơi cấp
        public string Truong { get; set; }  // Trường
        public string Khoa { get; set; }  // Khóa
        public string DonViThamGiaHuanLuyen { get; set; }  // Đơn vị tham gia huấn luyện
        public double DieuLenhCAND { get; set; }  // Điều lệnh CAND
        public double VoThuatCAND { get; set; }  // Võ thuật CAND
        public double KienThucBoTro { get; set; }  // Kiến thức bổ trợ
        public double SungNganHS9 { get; set; }  // Súng ngắn HS9
        public double SungAK { get; set; }  // Súng AK
        public double KyThuatChienDau { get; set; }  // Kỹ thuật chiến đấu
        public double KyThuatVanDongDuoiNuoc { get; set; }  // Kỹ thuật vận động dưới nước
        public double ChienThuatChienDau { get; set; }  // Chiến thuật chiến đấu
        public double RenTheLuc { get; set; }  // Rèn thể lực

        // Tính toán điểm trung bình
        public double DiemTB
        {
            get
            {
                double[] scores = new double[]
                {
                    DieuLenhCAND, VoThuatCAND, KienThucBoTro, SungNganHS9, SungAK,
                    KyThuatChienDau, KyThuatVanDongDuoiNuoc, ChienThuatChienDau, RenTheLuc
                };

                double sum = 0;
                foreach (var score in scores)
                {

                    sum += score;

                }

                return scores.Length > 0 ? sum / scores.Length : 0;
            }
        }

        // Xếp loại dựa trên điểm trung bình
        public string XepLoai
        {
            get
            {
                if (DiemTB >= 9.0)
                {
                    return "Xuất sắc";
                }
                else if (DiemTB >= 8.0)
                {
                    return "Giỏi";
                }
                else if (DiemTB >= 7.0)
                {
                    return "Khá";
                }
                else if (DiemTB >= 6.5)
                {
                    return "Trung bình khá";
                }
                else if (DiemTB >= 5.0)
                {
                    return "Trung bình";
                }
                else
                {
                    return "Không đạt yêu cầu";
                }
            }
        }
    }
}
