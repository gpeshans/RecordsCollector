<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" CodeBehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Records Collector</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" type="image/x-icon" href="/images/favicon.ico" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="css/styles.css" />
    <script type="text/javascript" src="js/Silverlight.js"></script>
    <script type="text/javascript" src="js/onerror.js"></script>
</head>
<body>
    <div class="container">
        <div class="top-content">
            <div class="logo">
                <img src="images\finki-logo-9.png" alt="" />
            </div>
            <div class="masthead">
                <h3 class="muted">
                    Веб апликација за собирање примероци</h3>
                <div class="navbar">
                    <div class="navbar-inner">
                        <div class="container">
                            <ul class="nav">
                                <li class="active"><a href="#">Упатство</a></li>
                                <li><a href="Numbers.aspx">Цифри</a></li>
                                <li><a href="Names.aspx">Имиња</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!-- /.navbar -->
            </div>
        </div>
        <div class="main-content">
            <h3>
                Добредојдовте на системот за прибирање на аудио снимки!</h3>
            <br />
            <div class="span4">
                <p style="text-align: left;">
                    <b>Упатство</b><br />
                    <br />
                    Битно е да го следите дефинираниот водич од системот. Најбитно е да креирате квалитетни
                    снимки со соодветни и конзистентни транскрипции. Секоја неконзистентност на снимката
                    со транскрипцијата е голем проблем за нас. Изговорените аудио снимки автоматски
                    ќе се транскриптираат со текстот што ќе го изговорите. ВАША ЗАДАЧА Е ТОЧНО ДА ГО
                    ИЗГОВОРИТЕ ТЕКСТОТ ШТО ЌЕ ВИ СЕ ПРИКАЖЕ. Истовремено ќе можете и да ја преслушате
                    сниманата аудио снимка. Обидете се снимката да се снима во што е можно потивка атмосфера,
                    без некои позадински звуци и шумови. Доколку сметате дека снимката не е квалитетна
                    поради било која причина, Ве молиме да ја преснимате. По снимањето на секоја снимка,
                    на крај, мора да кликнете на копчето Upload за снимката да биде зачувана во базата
                    на податоци. На веб страницата се наоѓаат два дела. Едниот е за собирање на снимки
                    на цифрите од 0-9, а другиот е за снимање на најчестите имиња во Македонија. Имате
                    за задача да креирате по 5 снимки за секоја цифра поединечно и 5 снимки од 10 имиња
                    кои кои ќе ви се прикажат на екранот.
                    <br />
                    Дополнително, овде е поставено и видео на кое е прикажан целиот процес на снимање
                    и зачувување на снимките. Ви препорачуваме да користите Internet Explorer. Ако не
                    сте сигурни како се користи системот, Ве молиме контактирајте не на peda.team@gmail.com.
                    <br />
                    <br />
                    Благодариме на разбирањето,
                    <br />
                    Горан и Даниел.
                </p>
            </div>
            <div class="span4">
                <iframe width="500" height="300" src="http://www.youtube.com/embed/xgKjp1pq7iI?feature=player_detailpage"
                    frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
    <footer>
        <p>
            © PEDATeam 2013</p>
    </footer>
    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
