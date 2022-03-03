using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSaveIDEditor
{
    public interface Locale
    {
        string Str_Title();
        string Str_Empty();
        string Str_Load();
        string Str_Save();
        string Str_Save_File();
        string Str_Current_ID();
        string Str_New_ID();
        string Str_Guide();
        string Str_Show_Guide();
        string Msg_Save_New_SteamID64();
        string Msg_Save_Orig_SteamID64();
        string Msg_File_Saved();
        string Msg_Slot_Copy_To_Clipboard();
        string Msg_Slot_Write_From_Clipboard();
    }

    public class English : Locale
    {
        string Locale.Str_Title() { return "ELDEN RING SteamID Save Editor"; }
        string Locale.Str_Empty() { return "Empty"; }
        string Locale.Str_Load() { return "Load"; }
        string Locale.Str_Save() { return "Save"; }
        string Locale.Str_Save_File() { return "Save File:"; }
        string Locale.Str_Current_ID() { return "Current ID:"; }
        string Locale.Str_New_ID() { return "New ID:"; }
        string Locale.Str_Show_Guide() { return "Show Guide"; }
        string Locale.Msg_Save_New_SteamID64() { return "Save as new SteamID64: {0}"; }
        string Locale.Msg_Save_Orig_SteamID64() { return "Save as original SteamID64: {0}"; }
        string Locale.Msg_File_Saved() { return "File saved!"; }
        string Locale.Msg_Slot_Copy_To_Clipboard() { return "Copy savedata from slot: {0} to Windows clipboard (as Base64 formatted text)"; }
        string Locale.Msg_Slot_Write_From_Clipboard() { return "Write savedata to slot: {0}, please save file!"; }
        string Locale.Str_Guide()
        {
            return "Save Location: %APPDATA%\\EldenRing\\{SteamID}\\ER0000.sl2\r\n\r\n" +
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
    }

    public class Chinese : Locale
    {
        string Locale.Str_Title() { return "《艾爾登法環》SteamID 存檔修改器"; }
        string Locale.Str_Empty() { return "無紀錄"; }
        string Locale.Str_Load() { return "讀取紀錄"; }
        string Locale.Str_Save() { return "儲存紀錄"; }
        string Locale.Str_Save_File() { return "遊戲存檔:"; }
        string Locale.Str_Current_ID() { return "目前 ID:"; }
        string Locale.Str_New_ID() { return "替換 ID:"; }
        string Locale.Str_Show_Guide() { return "顯示教學說明"; }
        string Locale.Msg_Save_New_SteamID64() { return "儲存為新的 SteamID64: {0}"; }
        string Locale.Msg_Save_Orig_SteamID64() { return "儲存為原始 SteamID64: {0}"; }
        string Locale.Msg_File_Saved() { return "檔案已儲存!"; }
        string Locale.Msg_Slot_Copy_To_Clipboard() { return "已複製紀錄欄位: {0} 至剪貼簿 (Base64 文字格式)"; }
        string Locale.Msg_Slot_Write_From_Clipboard() { return "已寫入至紀錄欄位: {0}，請儲存紀錄"; }
        string Locale.Str_Guide()
        {
            return "存檔路徑: %APPDATA%\\EldenRing\\{SteamID}\\ER0000.sl2\r\n\r\n" +
                "教學 1: 別人存檔轉換成自己存檔\r\n\r\n" +
                "1. 讀取自己的存檔，複製目前 ID 的內容 (這是你的 SteamID)\r\n" +
                "2. 讀取別人的存檔，貼上你的 SteamID 到替換 ID 欄位\r\n" +
                "3. 儲存紀錄至自己的存檔所在的資料夾 (你的 SteamID)\r\n\r\n" +
                "教學 2: 複製別人存檔欄位至自己存檔欄位\r\n\r\n" +
                "1. 進入遊戲，開始新遊戲並存檔退出遊戲\r\n" +
                "2. 讀取別人的存檔，右邊欄位按鈕點選滑鼠左鍵複製資料 (Base64 文字格式)\r\n" +
                "3. 讀取自己的存檔，右邊欄位按鈕點選滑鼠右鍵寫入資料\r\n" +
                "4. 儲存紀錄至自己的存檔所在的資料夾 (你的 SteamID)";
        }
    }
}
