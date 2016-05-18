    idleMax = 30; // Logout after 30 minutes of IDLE
    idleTime = 0;

    function checkpage() {
        console.log("InIN");
      
        setInterval(timerIncrement, 60000);
        $(this).mousemove(function (e) { idleTime = 0; });
        $(this).keypress(function (e) { idleTime = 0; });
     
       
      
        

    }

    function timerIncrement() {
        console.log("123");
       
        idleTime = idleTime + 1;
        if (idleTime > idleMax) {
           
             window.location.href = 'Account/KillSession';

          

        }
    }
  
