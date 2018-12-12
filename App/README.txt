Po tej lekcji powinienie� wiedzie�:
	- Czym jest Unit test
	- Czym jest podej�cie AAA
	- Jak nazywa� testy
	- Czym s� atrapy
	- Czym jest Sut
		
W tej lekcji poznasz takie narz�dzia jak:
	- XUnit
	- Shouldly
	- NSubstitute
	

Unit test
	Test sprawdzaj�cy tylko jeden element w systemie. Powinien by� prosty oraz szybki.

AAA (Arrange - Act - Assert) 
	Podej�cie do tworzenia Unit testow, sk�adaj�ce si� z nast�puj�cych etap�w:
	- Arrange - przygotowanie danych i abstrakcji, kt�re b�da testowane
	- Act - wykonanie testowanej funkcji
	- Assert - sprawdzenie czy wszystko wykona�o si� zgodnie z za�o�eniami. Asercja nie powinna zawiera� �adnej logiki.
	Unit test powinien zawiera� tylko jedn� asercj�.

	
Nazewnictwo test�w
	Istnieje wiele konwencji nazewnictwa test�w jednostkowych. Wszystkie ��czy to, i� nazwa testu jednostkowego 
	powinna jasno m�wi� o tym co test sprawdza, jakie posiada dane wejsciowe oraz jakiego rezultatu oczekuje.

Atrapa
	Obiekt, kt�ry zosta� stworzony tylko po to aby zasymulowa� jakie� zachowanie, zwr�ci� oczekiwan� warto�� 
	lub nie robi� nic - jedynie wype�ni� pola wymagane.
	Istniej� r�ne typy atrap. (Zostan� wyja�nione w innej lekcji).

Sut
	System Under Test - jest to obiekt, kt�ry jest testowany przez Unit test
	

Prezentowany przyk�ad.
	Do solucji zosta�y dodane dwa projekty
	- logic - zawiera logik�, kt�ra b�dzie testowana
	- test - zawiera unit testy. Zwyczajowo projekty zawieraj�ce testy jednostkowe nazywa si� zgodnie z konwencj�:
		nazwa_projektu.Tests.Unit	

Do projektu z testami zosta�y zainstalowane nast�puj�ce paczki:
Microsoft.NET.Test.Sdk - microsoftowe SDK do test�w
NSubstitute - biblioteka do tworzenia atrap
shouldly - biblioteka do asercji test�w
xunit - jeden z najpopularniejszych framework�w do tworzenia test�w jednostkowych
xunit.runner.console - biblioteka umo�liwiaj�ca uruchamianie test�w w konsoli 
xunit.runner.visualstudio - biblioteka umo�liwiaj�ca uruchamianie test�w w Visual Studio


Jak podej�� do tworzenia testu jednostkowego.

Wybieramy metod�, kt�r� b�dziemy testowa� i okre�lamy wszystkie �cie�ki wykonania metody, pozytywne i negatywne.
Metoda Get(decimal cost) interfejsu IPaymentMethodProvider zale�nie od podanego argumentu zwraca odpowiedni� metod�
p�atno�ci:

1) dla kosztu powy�ej 1000, zwracana jest p�atno�� kart�
2) dla kosztu poni�ej 1000, zwracana jest p�atno�� got�wk�

nale�y sprawdzi� r�wnie� warto�ci szczeg�lne dla argumentu

3) dla kosztu r�wnego 0, zwracana jest p�atno�� got�wk�
4) dla kosztu poni�ej 0, zwracana jest p�atno�� got�wk�

s� to 4 r�ne �cie�ki i dla ka�dej nale�y stworzy� test.

Plik z testami powinien nazywa� tak jak plik z testowan� logik� z dodanym sufixem 'Tests'.
W projekcie testowym, pod analogiczn� �cie�k� jak w projekcie z logik� tworzymy plik PaymentMethodProviderTests.cs
Wewn�trz tworzymy prywatn� w�a�ciwo�� testowanego typu o nazwie 'Sut'. W konstruktorze inicjalizujemy nowy obiekt.
Ka�dy test b�dzie osobn� metod� - powinna by� publiczna oraz nie zwraca� warto�ci (public void). Testy powinny by� 
r�wnie� oznaczone atrybutem [Fact] - dostarczany przez framework XUnit.
Nazwy zgodnie z konwencj� tworzymy tak by jasno opisywa�y test.

W ka�dym z test�w tworzymy atrap� argumentu 'cost' - w sekcji Arrange.
W sekcji Act wywo�ujemy metod� Get przekazuj�c utworzony argument.
W sekcji Assert sprawdzamy rezultat wykonanej akcji, wykorzystuj�� metod� ShouldBe - dostarczan� przez bibliotek� Shouldly

		** Zerknij r�wnie� do OrderPriceCalculatorTests.cs **

Bardziej skomplikowanym przyk�adem jest OrderResolverTests.cs

W tym przypadku nie jeste�my w stanie tak prosto stworzy� obiektu OrderResolver, poniewa� przyjmuj� on argumenty w konstrukorze.
Argumnety naszego SUTa tworzymy r�wnie� jako prywatne w�a�ciwo�ci klasy. Natomiast w konstuktorze tworzymy ich atrapy,
przy pomocy Substitute.For<T>() - dostarczane przez bibliotek� NSubstitiute.
Wywo�anie tej metody utworzy implementacj� przekazanego jako T interfejsu (atrap�).
Analogicznie tworzymy atrapy listy produkt�w i doros�ego u�ytkownika, poniewa� s� reu�ywane w wielu testach.

Pierwszy test jest prosty, jedyn� nowo�ci� jest przechwycenie wyj�tku w assercji, wykorzystuj�c 
Should.Throw<T>() - dostarczane przez bibliotek� Shoudly.
Sprawdzany jest zar�wno typ rzuconego wyj�tku jak i wiadomo��.

Kolejne testy zaprzeczaj� wcze�niej opisanym zasadom.
Zamiast atrybutu [Fact] zosta� dodany atrybut [Theory] oraz dodatkowe atrybuty [InlineData].
Metody r�ni� si� r�wnie� tym �e przyjmuj� argumenty.

Teorie s� wykorzystywane w przypadku, gdy testy s� bardzo podobne i r�ni� si� jedynie pojedynczymi parametrami.
Dla ka�dego atrybutu [InlineData] zostanie wykonany test dla podanych wewn�trz parametr�w.

Testy posiadaj� r�wnie� predefiniowanie zachowa� atrap.
Oznacza to �e mo�emy wymusi� na danej metodzie konkretne zachowanie.

Wygl�da to w nast�puj�cy spos�b: 
	OrderPriceCalculator.Calculate(ProductList).Returns(orderPrice);
piszemy kod, kt�ry w normalnym �rodowisku wykonywa�by metod� OrderPriceCalculator.Calculate() 
dla parametru ProductList, dodajemy jednak wywo�anie metody Returns() - kt�rej przekazujemy warto�� jak� ma zwr�ci� to wywo�anie.

W te�cie GivenOrderPrice_ThenItChecksIfPaymentMethodProviderIsCalledWithProperArgument
wymuszamy aby OrderPriceCalculator.Calculate(ProductList) zwraca� konkretny argument, 
nast�pnie wykonujemy akcj�, kt�r� testujemy.

Test zapobiega sytuacji, gdy kto� wyedytowa�by kod w ten spos�b �e utracona zosta�aby sp�jno�� danych.
W Assercji sprawdzamy czy metoda PaymentMethodProvider.Get() otrzyma�a taki sam parametr jak zwr�ci� OrderPriceCalculator.
Do tego zosta�a wykorzystana metoda Received (biblioteka shoudly) - kt�ra sprawdza ile razy zosta�a wywo�ana dana metoda.
U�ycie wygl�da nast�puj�co:

obiekt.Received(oczekiwana ilo�� wywo�a�).metoda(parametry);




Jak uruchomi� testy?
Visual Studio: Test Explorer -> Run All
Console: dotnet tests