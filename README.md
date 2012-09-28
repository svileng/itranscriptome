# iTranscriptome

iTranscriptome is a Windows application for storing and organising 
transcriptomic datasets from the [Gene Expression Omnibus](http://www.ncbi.nlm.nih.gov/gds/). It was developed 
during my final year at Royal Holloway University of London, with the help of Horacio Caniza and
Dr. Alberto Paccanaro from [Paccanaro Lab](http://www.paccanarolab.org/). Unfortunately, parts of it are still unfinished.

The application uses a variation of the Model-View-Controller architectural pattern and a custom Object-Relational Mapping system, 
both designed by me. Other points of interest are the parser for transcriptomic datasets and the caching system 
for the ORM (one of the few optimisations I was able to implement, as the amount of data can be considerably large). There is also a small number of simple unit tests in the Test project (unfortunately, university final year projects are not always Agile and TDD-oritented).

As I mentioned, parts of the application were left unfinished (check commit log) and it was not extensively tested. However, most of the code I wrote is documented in good detail, so it might be still useful to someone.

Note: this is a personal repository. The official repository will be 
available at [paccanarolab.org](http://www.paccanarolab.org/).