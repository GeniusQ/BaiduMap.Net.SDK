using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Diagnostics;

namespace BaiduMapSdkUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private string ak = "B8ac45482b021a8ee535efb37ada1004";
        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://api.map.baidu.com/direction/v1?mode=driving&origin=清华大学&destination=北京大学&origin_region=北京&destination_region=北京&output=json&ak=" + ak;
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            string json = wc.DownloadString(url);
            var jo = Newtonsoft.Json.Linq.JObject.Parse(json);
            var r = jo.Value<string>("message").ToLower();
            Debug.WriteLine(json);

            Assert.AreEqual("ok", r, "百度地图返回信息不正确");
            
        }
    }
}
