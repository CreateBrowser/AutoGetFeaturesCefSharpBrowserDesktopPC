    
        
[![PayPal Logo](https://raw.githubusercontent.com/CreateBrowser/ACefSharpChromiumBrowserDesktop/master/PayPal.jpg)](https://createbrowser.github.io/ACefSharpChromiumBrowserDesktop/PayPal.html)

<div class="login-bottom-links">  
   <br> <a href="https://developer.paypal.com/docs/classic/paypal-payments-standard/integration-guide/html_example_donate/#fixed-contribution-amount" class="link">Donate: Sample HTML button code Basic Donate button </a>
 
 <a href="https://developer.paypal.com/docs/classic/paypal-payments-standard/integration-guide/create_payment_button/" class="link">Create a payment button Additional information </a>
        
<a  href="http://element-cn.eleme.io/#/en-US/component/icon" class="link"> button Additional information Element provides a set of common icons</a> <br />
 PayPal Payments </div> 

   

[![ donate paypay@2x.png ](https://createbrowser.github.io/ACefSharpChromiumBrowserDesktop/paypay@2x.png)](https://createbrowser.github.io/ACefSharpChromiumBrowserDesktop/PayPal.html)

	
>	
	
<html>
<head>
  <meta charset="UTF-8">
  <!-- import CSS -->
  <link rel="stylesheet" href="https://unpkg.com/element-ui/lib/theme-chalk/index.css">
</head>
<body>
  <div id="app">
    <el-button @click="visible = true">Button</el-button>
    <el-dialog :visible.sync="visible" title="Hello world">
  <input type="image" name="submit" src="https://createbrowser.github.io/ACefSharpChromiumBrowserDesktop/button.png" alt="PayPal">
    </el-dialog>
  </div>
</body>
  <!-- import Vue before Element -->
  <script src="https://unpkg.com/vue/dist/vue.js"></script>
  <!-- import JavaScript -->
  <script src="https://unpkg.com/element-ui/lib/index.js"></script>
  <script>
    new Vue({
      el: '#app',
      data: function() {
        return { visible: false }
      }
    })
  </script>
</html>


© 2018 GitHub, Inc. 
