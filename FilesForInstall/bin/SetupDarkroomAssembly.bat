:: Import EPE printer into Darkroom Pro
reg import setupEPE_RasterPrinter_assembly.reg

:: Create the EPE package group (If ED is not running, this has to be done manually)
if exist x:\Packages copy EventPhotoEmailer.pgrp x:\Packages\EventPhotoEmailer.pgrp


:: Copy sample proof templates (If ED is not running, this has to be done manually)
if exist x:\Templates mkdir x:\Templates\ProofBorderExample
if exist X:\Templates\ProofBorderExample copy ProofBorderExample\*.* X:\Templates\ProofBorderExample\

start SupportFiles\start.exe