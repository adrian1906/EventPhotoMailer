:: Import EPE printer into Darkroom Pro
reg import %cd%\bin\setupEPE_RasterPrinter.reg

:: Create the EPE package group (If ED is not running, this has to be done manually)
if exist x:\Packages copy %cd%\bin\EventPhotoEmailer.pgrp x:\Packages\EventPhotoEmailer.pgrp
:: Copy sample proof templates (If ED is not running, this has to be done manually)

if exist x:\Templates mkdir x:\Templates\ExampleProofBorders
if exist X:\Templates\ExampleProofBorders copy %cd%\bin\ExampleProofBorders\*.* X:\Templates\ExampleProofBorders\



