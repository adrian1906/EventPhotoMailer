:: Import EPE printer into Darkroom Pro
reg import %cd%\bin\removeEPE_RasterPrinter.reg

:: Remove the EPE package group (If ED is not running, this has to be done manually)
if exist x:\packages\EventPhotoEmailer.pgrp del x:\packages\EventPhotoEmailer.pgrp

:: Remove .dll file
del %systemroot%\see32.dll
