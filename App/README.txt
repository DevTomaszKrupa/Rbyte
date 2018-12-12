Po tej lekcji powinienieæ wiedzieæ:
	- Czym jest Unit test
	- Czym jest podejœcie AAA
	- Jak nazywaæ testy
	- Czym s¹ atrapy
	- Czym jest Sut
		
W tej lekcji poznasz takie narzêdzia jak:
	- XUnit
	- Shouldly
	- NSubstitute
	

Unit test
	Test sprawdzaj¹cy tylko jeden element w systemie. Powinien byæ prosty oraz szybki.

AAA (Arrange - Act - Assert) 
	Podejœcie do tworzenia Unit testow, sk³adaj¹ce siê z nastêpuj¹cych etapów:
	- Arrange - przygotowanie danych i abstrakcji, które bêda testowane
	- Act - wykonanie testowanej funkcji
	- Assert - sprawdzenie czy wszystko wykona³o siê zgodnie z za³o¿eniami. Asercja nie powinna zawieraæ ¿adnej logiki.
	Unit test powinien zawieraæ tylko jedn¹ asercjê.

	
Nazewnictwo testów
	Istnieje wiele konwencji nazewnictwa testów jednostkowych. Wszystkie ³¹czy to, i¿ nazwa testu jednostkowego 
	powinna jasno mówiæ o tym co test sprawdza, jakie posiada dane wejsciowe oraz jakiego rezultatu oczekuje.

Atrapa
	Obiekt, który zosta³ stworzony tylko po to aby zasymulowaæ jakieœ zachowanie, zwróciæ oczekiwan¹ wartoœæ 
	lub nie robiæ nic - jedynie wype³niæ pola wymagane.
	Istniej¹ ró¿ne typy atrap. (Zostan¹ wyjaœnione w innej lekcji).

Sut
	System Under Test - jest to obiekt, który jest testowany przez Unit test
	

Prezentowany przyk³ad.
	Do solucji zosta³y dodane dwa projekty
	- logic - zawiera logikê, która bêdzie testowana
	- test - zawiera unit testy. Zwyczajowo projekty zawieraj¹ce testy jednostkowe nazywa siê zgodnie z konwencj¹:
		nazwa_projektu.Tests.Unit	

Do projektu z testami zosta³y zainstalowane nastêpuj¹ce paczki:
Microsoft.NET.Test.Sdk - microsoftowe SDK do testów
NSubstitute - biblioteka do tworzenia atrap
shouldly - biblioteka do asercji testów
xunit - jeden z najpopularniejszych frameworków do tworzenia testów jednostkowych
xunit.runner.console - biblioteka umo¿liwiaj¹ca uruchamianie testów w konsoli 
xunit.runner.visualstudio - biblioteka umo¿liwiaj¹ca uruchamianie testów w Visual Studio


Jak podejœæ do tworzenia testu jednostkowego.

Wybieramy metodê, któr¹ bêdziemy testowaæ i okreœlamy wszystkie œcie¿ki wykonania metody, pozytywne i negatywne.
Metoda Get(decimal cost) interfejsu IPaymentMethodProvider zale¿nie od podanego argumentu zwraca odpowiedni¹ metodê
p³atnoœci:

1) dla kosztu powy¿ej 1000, zwracana jest p³atnoœæ kart¹
2) dla kosztu poni¿ej 1000, zwracana jest p³atnoœæ gotówk¹

nale¿y sprawdziæ równie¿ wartoœci szczególne dla argumentu

3) dla kosztu równego 0, zwracana jest p³atnoœæ gotówk¹
4) dla kosztu poni¿ej 0, zwracana jest p³atnoœæ gotówk¹

s¹ to 4 ró¿ne œcie¿ki i dla ka¿dej nale¿y stworzyæ test.

Plik z testami powinien nazywaæ tak jak plik z testowan¹ logik¹ z dodanym sufixem 'Tests'.
W projekcie testowym, pod analogiczn¹ œcie¿k¹ jak w projekcie z logik¹ tworzymy plik PaymentMethodProviderTests.cs
Wewn¹trz tworzymy prywatn¹ w³aœciwoœæ testowanego typu o nazwie 'Sut'. W konstruktorze inicjalizujemy nowy obiekt.
Ka¿dy test bêdzie osobn¹ metod¹ - powinna byæ publiczna oraz nie zwracaæ wartoœci (public void). Testy powinny byæ 
równie¿ oznaczone atrybutem [Fact] - dostarczany przez framework XUnit.
Nazwy zgodnie z konwencj¹ tworzymy tak by jasno opisywa³y test.

W ka¿dym z testów tworzymy atrapê argumentu 'cost' - w sekcji Arrange.
W sekcji Act wywo³ujemy metodê Get przekazuj¹c utworzony argument.
W sekcji Assert sprawdzamy rezultat wykonanej akcji, wykorzystuj¹æ metodê ShouldBe - dostarczan¹ przez bibliotekê Shouldly

		** Zerknij równie¿ do OrderPriceCalculatorTests.cs **

Bardziej skomplikowanym przyk³adem jest OrderResolverTests.cs

W tym przypadku nie jesteœmy w stanie tak prosto stworzyæ obiektu OrderResolver, poniewa¿ przyjmujê on argumenty w konstrukorze.
Argumnety naszego SUTa tworzymy równie¿ jako prywatne w³aœciwoœci klasy. Natomiast w konstuktorze tworzymy ich atrapy,
przy pomocy Substitute.For<T>() - dostarczane przez bibliotekê NSubstitiute.
Wywo³anie tej metody utworzy implementacjê przekazanego jako T interfejsu (atrapê).
Analogicznie tworzymy atrapy listy produktów i doros³ego u¿ytkownika, poniewa¿ s¹ reu¿ywane w wielu testach.

Pierwszy test jest prosty, jedyn¹ nowoœci¹ jest przechwycenie wyj¹tku w assercji, wykorzystuj¹c 
Should.Throw<T>() - dostarczane przez bibliotekê Shoudly.
Sprawdzany jest zarówno typ rzuconego wyj¹tku jak i wiadomoœæ.

Kolejne testy zaprzeczaj¹ wczeœniej opisanym zasadom.
Zamiast atrybutu [Fact] zosta³ dodany atrybut [Theory] oraz dodatkowe atrybuty [InlineData].
Metody ró¿ni¹ siê równie¿ tym ¿e przyjmuj¹ argumenty.

Teorie s¹ wykorzystywane w przypadku, gdy testy s¹ bardzo podobne i ró¿ni¹ siê jedynie pojedynczymi parametrami.
Dla ka¿dego atrybutu [InlineData] zostanie wykonany test dla podanych wewn¹trz parametrów.

Testy posiadaj¹ równie¿ predefiniowanie zachowañ atrap.
Oznacza to ¿e mo¿emy wymusiæ na danej metodzie konkretne zachowanie.

Wygl¹da to w nastêpuj¹cy sposób: 
	OrderPriceCalculator.Calculate(ProductList).Returns(orderPrice);
piszemy kod, który w normalnym œrodowisku wykonywa³by metodê OrderPriceCalculator.Calculate() 
dla parametru ProductList, dodajemy jednak wywo³anie metody Returns() - której przekazujemy wartoœæ jak¹ ma zwróciæ to wywo³anie.

W teœcie GivenOrderPrice_ThenItChecksIfPaymentMethodProviderIsCalledWithProperArgument
wymuszamy aby OrderPriceCalculator.Calculate(ProductList) zwraca³ konkretny argument, 
nastêpnie wykonujemy akcjê, któr¹ testujemy.

Test zapobiega sytuacji, gdy ktoœ wyedytowa³by kod w ten sposób ¿e utracona zosta³aby spójnoœæ danych.
W Assercji sprawdzamy czy metoda PaymentMethodProvider.Get() otrzyma³a taki sam parametr jak zwróci³ OrderPriceCalculator.
Do tego zosta³a wykorzystana metoda Received (biblioteka shoudly) - która sprawdza ile razy zosta³a wywo³ana dana metoda.
U¿ycie wygl¹da nastêpuj¹co:

obiekt.Received(oczekiwana iloœæ wywo³añ).metoda(parametry);




Jak uruchomiæ testy?
Visual Studio: Test Explorer -> Run All
Console: dotnet tests