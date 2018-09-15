using System;
using System.Collections.Generic;

namespace InfoSystem.App.DataBase.Interfaces
{
    public interface IUser
    {
        Guid UserId { get; }
        string Login { get; } 
        double ShopTurnover { get; }
        string Password { get; set; }
        string Nickname { get; set; }
        string ShopName { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Uri Photo { get; set; }
        Uri FeedbackLink { get; set; } // VK, Tg, etc.
        
        int ShowIncome();
        int ShowCharges();
        List<IMessage> ShowMessages();
        List<IProduct> ShowGoods();
        int GetMessagesCount();
        void UploadPhoto(Uri urlToPhoto);
        void UpdatePassword(string newPassword);
        void UpdateNickname(string newNickname);
        void UpdateEmail(string newEmail);
        void AddProduct(IProduct product);
        void DeleteProduct(IProduct product);
    }
}