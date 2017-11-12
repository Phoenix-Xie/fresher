using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
using System.Data;

/// <summary>
/// Safe 的摘要说明
/// </summary>
public class Safe

{
    public Safe()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }


    public string Relace_special_characters(string str)
    {
        //特殊字符对照表
        /*    / 　　' 　 "   　+  　-
            あ　　い 　う　　え　　お
        */
        string new_str;
        Regex quotation = new Regex("[\"\'\']");
        new_str = Regex.Replace(str, @"[']", "い");
        new_str = Regex.Replace(str, "[\"]", "あ");
        new_str = Regex.Replace(str, @"[']", "う");
        new_str = Regex.Replace(str, @"[+]", "え");
        new_str = Regex.Replace(str, @"[-]", "お");
        return new_str;
    }
    public string Encrypt(string pwd, string key = "0")
    {
        List<string> keys = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int counter = 0;
        if (key != "0")
        {
            foreach (char i in key)
            {
                keys[counter] = i.ToString();
                counter++;
            }
        }
        List<string> secret = new List<string> { "吹", "灭", "读", "书", "灯", "一", "身", "都", "是", "月" };
        for (int j = 0; j < 10; j++)
        {
            pwd = Regex.Replace(pwd, keys[j], secret[j]);
        }
        return pwd;
    } //加密字符后返回
    public string Decrypt(string pwd, string key = "0")
    {
        List<string> keys = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int counter = 0;
        if (key != "0")
        {
            foreach (char i in key)
            {
                keys[counter] = i.ToString();
                counter++;
            }
        }
        List<string> secret = new List<string> { "吹", "灭", "读", "书", "灯", "一", "身", "都", "是", "月" };
        for (int j = 0; j < 10; j++)
        {
            pwd = Regex.Replace(pwd, secret[j], keys[j]);
        }

        return pwd;
    } //解密字符后返回

    
    public string Test_pwd_safe(string pwd, string pwd_twice)
    {
        Regex number = new Regex("[0-9]");
        Regex Uppercharacter = new Regex("[A-Z]");
        Regex Lowercharacter = new Regex("[a-z]");
        Regex others = new Regex("[^0-9a-zA-Z]");
        Regex Chinese_character = new Regex("[\u4E00 - \uFA29]");//匹配汉字
        Regex space = new Regex("/s");
        if (pwd.Length > 15)
        {
            return "密码不得超过15位";
        }
        else if (pwd != pwd_twice)
        {
            return "两次密码不相符！！！";
        }
        else if (pwd == "")
        {
            return "密码不能为空";
        }
        else if (pwd.Length < 5)
        {
            return "密码必须五位以上，但不超过15位";
        }
        else if (!(number.IsMatch(pwd) && Uppercharacter.IsMatch(pwd) && Lowercharacter.IsMatch(pwd) && others.IsMatch(pwd)))//如果没有出现大小写字母，数字，特殊字符需要更改
        {
            return "密码里必须有数字，大小写字母和特殊字符混合";
        }
        else if (space.IsMatch(pwd))
        {
            return "密码中不允许有空格";
        }
        else if (Chinese_character.IsMatch(pwd))
        {
            return "密码中不允许包含有汉字";
        }
        else
        {
            return null;
        }
       
    }

    public string Test_name_safe(string name)
    {
        if (name.Length > 15)
        {
            return "用户名长度不能超过15位";
        }
        else if (name == "")
        {
            return "用户名不能为空";
        }
        else
        {
            return null;
        }
    }

}
