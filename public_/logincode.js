function check(form)
    {
      if(form.userid.value == "admin" && form.pswrd.value == "admin")
      {
        window.open('admin.html', '_self')
      }
      else if(form.userid.value == "user" && form.pswrd.value == "user")
      {
        window.open('user.html', '_self')
      }
      else
      {
        alert("Error Password or Username")
      }
    }