using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSaveIDEditor.Locale
{
    public interface ITranslate
    {
        string STR_TITLE { get; }
        string STR_EMPTY { get; }
        string STR_LOAD { get; }
        string STR_SAVE { get; }
        string STR_SAVE_FILE { get; }
        string STR_CURRENT_ID { get; }
        string STR_NEW_ID { get; }
        string STR_GUIDE { get; }
        string STR_SHOW_GUIDE { get; }
        string MSG_SAVE_NEW_STEAMID64 { get; }
        string MSG_SAVE_ORIG_STEAMID64 { get; }
        string MSG_SAVEDATA_DOWNGRADE { get; }
        string MSG_FILE_SAVED { get; }
        string MSG_SLOT_COPY_TO_CLIPBOARD { get; }
        string MSG_SLOT_WRITE_FROM_CLIPBOARD { get; }
    }

    public class English : ITranslate
    {
        string ITranslate.STR_TITLE { get; } = "ELDEN RING SteamID Save Editor";
        string ITranslate.STR_EMPTY { get; } = "Empty";
        string ITranslate.STR_LOAD { get; } = "Load";
        string ITranslate.STR_SAVE { get; } = "Save";
        string ITranslate.STR_SAVE_FILE { get; } = "Save File:";
        string ITranslate.STR_CURRENT_ID { get; } = "Current ID:";
        string ITranslate.STR_NEW_ID { get; } = "New ID:";
        string ITranslate.STR_SHOW_GUIDE { get; } = "Show Guide";
        string ITranslate.MSG_SAVE_NEW_STEAMID64 { get; } = "Save as new SteamID64: {0}";
        string ITranslate.MSG_SAVE_ORIG_STEAMID64 { get; } = "Save as original SteamID64: {0}";
        string ITranslate.MSG_SAVEDATA_DOWNGRADE { get; } = "Downgrade savedata to version 1.0.2.1";
        string ITranslate.MSG_FILE_SAVED { get; } = "File saved!";
        string ITranslate.MSG_SLOT_COPY_TO_CLIPBOARD { get; } = "Copy savedata from slot: {0} to Windows clipboard (as Base64 formatted text)";
        string ITranslate.MSG_SLOT_WRITE_FROM_CLIPBOARD { get; } = "Write savedata to slot: {0}, please save file!";
        string ITranslate.STR_GUIDE { get; } = "Save Location: %APPDATA%\\EldenRing\\{SteamID}\\ER0000.sl2\r\n\r\n" +
            "Guide 1: Convert someone's savedata to your own\r\n\r\n" +
            "1. Load your savedata file, copy the text from 'Current ID''. (This is your SteamID)\r\n" +
            "2.Load someone's savedata file, paste your SteamID to 'New ID'.\r\n" +
            "3.Save the file into your savedata folder. (Your SteamID)\r\n\r\n" +
            "Guide 2: Copy someone's save slot to your savedata\r\n\r\n" +
            "1.Start ELDEN RING and create new game, save and exit.\r\n" +
            "2.Load someone's savedata file, mouse LEFT click the button to copy the slot data. (Base64 formatted text)\r\n" +
            "3.Load your savedata file, mouse RIGHT click the button to wirte the slot data.\r\n" +
            "4.Save the file into your savedata folder. (Your SteamID)\r\n";
    }

    public class TChinese : ITranslate
    {
        string ITranslate.STR_TITLE { get; } = "《艾爾登法環》SteamID 存檔修改器";
        string ITranslate.STR_EMPTY { get; } = "無紀錄";
        string ITranslate.STR_LOAD { get; } = "讀取紀錄";
        string ITranslate.STR_SAVE { get; } = "儲存紀錄";
        string ITranslate.STR_SAVE_FILE { get; } = "遊戲存檔:";
        string ITranslate.STR_CURRENT_ID { get; } = "存檔 ID:";
        string ITranslate.STR_NEW_ID { get; } = "替換 ID:";
        string ITranslate.STR_SHOW_GUIDE { get; } = "顯示教學說明";
        string ITranslate.MSG_SAVE_NEW_STEAMID64 { get; } = "儲存為新的 SteamID64: {0}";
        string ITranslate.MSG_SAVE_ORIG_STEAMID64 { get; } = "儲存為原始 SteamID64: {0}";
        string ITranslate.MSG_SAVEDATA_DOWNGRADE { get; } = "將存檔降級為 1.0.2.1 版本";
        string ITranslate.MSG_FILE_SAVED { get; } = "檔案已儲存!";
        string ITranslate.MSG_SLOT_COPY_TO_CLIPBOARD { get; } = "已複製紀錄欄位: {0} 至剪貼簿 (Base64 文字格式)";
        string ITranslate.MSG_SLOT_WRITE_FROM_CLIPBOARD { get; } = "已寫入至紀錄欄位: {0}，請儲存紀錄";
        string ITranslate.STR_GUIDE { get; } = "存檔路徑: %APPDATA%\\EldenRing\\{SteamID}\\ER0000.sl2\r\n\r\n" +
            "教學 1: 別人存檔轉換成自己存檔\r\n\r\n" +
            "1. 讀取自己的存檔，複製存檔 ID 的內容 (這是你的 SteamID)\r\n" +
            "2. 讀取別人的存檔，貼上你的 SteamID 到替換 ID 欄位\r\n" +
            "3. 儲存紀錄至自己的存檔所在的資料夾 (你的 SteamID)\r\n\r\n" +
            "教學 2: 複製別人存檔欄位至自己存檔欄位\r\n\r\n" +
            "1. 進入遊戲，開始新遊戲並存檔退出遊戲\r\n" +
            "2. 讀取別人的存檔，右邊欄位按鈕點選滑鼠左鍵複製資料 (Base64 文字格式)\r\n" +
            "3. 讀取自己的存檔，右邊欄位按鈕點選滑鼠右鍵寫入資料\r\n" +
            "4. 儲存紀錄至自己的存檔所在的資料夾 (你的 SteamID)";
    }

    public class SChinese : ITranslate
    {
        string ITranslate.STR_TITLE { get; } = "《艾尔登法环》SteamID 存档修改器";
        string ITranslate.STR_EMPTY { get; } = "无纪录";
        string ITranslate.STR_LOAD { get; } = "读取纪录";
        string ITranslate.STR_SAVE { get; } = "保存纪录";
        string ITranslate.STR_SAVE_FILE { get; } = "游戏存档:";
        string ITranslate.STR_CURRENT_ID { get; } = "存档 ID:";
        string ITranslate.STR_NEW_ID { get; } = "替换 ID:";
        string ITranslate.STR_SHOW_GUIDE { get; } = "显示教学说明";
        string ITranslate.MSG_SAVE_NEW_STEAMID64 { get; } = "保存为新的 SteamID64: {0}";
        string ITranslate.MSG_SAVE_ORIG_STEAMID64 { get; } = "保存为原始 SteamID64: {0}";
        string ITranslate.MSG_SAVEDATA_DOWNGRADE { get; } = "将存档降级为 1.0.2.1 版本";
        string ITranslate.MSG_FILE_SAVED { get; } = "档案已保存!";
        string ITranslate.MSG_SLOT_COPY_TO_CLIPBOARD { get; } = "已拷贝记录栏位: {0} 至剪贴簿 (Base64 文字格式)";
        string ITranslate.MSG_SLOT_WRITE_FROM_CLIPBOARD { get; } = "已写入至记录栏位: {0}，请保存记录";
        string ITranslate.STR_GUIDE { get; } = "存档路径: %APPDATA%\\EldenRing\\{SteamID}\\ER0000.sl2\r\n\r\n" +
            "教学 1: 别人存档转换成自己存档\r\n\r\n" +
            "1. 读取自己的存档，拷贝存档 ID 的内容 (这是您的 SteamID)\r\n" +
            "2. 读取别人的存档，黏贴你的 SteamID 到替换 ID 栏位\r\n" +
            "3. 保存记录至自己的存档所在的文件夹 (您的 SteamID)\r\n\r\n" +
            "教学 2: 拷贝别人存档栏位至自己存档栏位\r\n\r\n" +
            "1. 进入游戏，开始新游戏并存档退出游戏\r\n" +
            "2. 读取别人的存档，右边栏位按钮点击鼠标左键拷贝资料 (Base64 文字格式)\r\n" +
            "3. 读取自己的存档，右边栏位按钮点击鼠标右键写入资料\r\n" +
            "4. 保存记录至自己存档所在的文件夹 (您的 SteamID)";
    }
}
