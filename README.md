# Fixers for sliders, hair, skins after werewolf patch - V2.2 Alpha 2022-07-03, V1.1 Sliders, 6/25/22 

## Additional Information
* This is a fork from MTS. 
* Original description by [CmarNYC](https://modthesims.info/member.php?u=3216596) who retired on earth and is now supporting the TS4 development in heaven.
* The same description for Alpha and Slider as cmarNYC uploaded it as one mod.

### Requirements:
* s4pe

## Description

These are two tools to fix sliders, alpha hairs, and skin details/overlays broken by the June 2022 werewolf patch. Both can be run on individual packages or as batch fixes.

TS4SliderConverter: Updates the HotSpotControls to the latest version, fixing sliders broken by the patch.

TS4AlphaConverter: (That's the best name I could think of.) Now recompresses LRLE textures to work in the game, with the options to convert LRLE textures to RLE2 and to convert RLE2 to LRLE. Recompressing keeps color slider compatibility. Fixes alpha hairs that have a strange appearance after the patch. Should also work for most or all skin overlays and skin details but testing is needed.

The option to update LRLE compression should work with default replacement skins.

For both, extract the zip files, open the folder, and run the .exe. Use the top button to convert packages, or select input and output folders to run in batch mode.

Both tools were done in haste, so please report problems! And when reporting problems, please upload or link to packages you were unable to convert successfully.

MANY thanks to Andrew at Sims4Studio for finding that the problem with LRLE textures after the patch is the compression. Basically, the image has to be reduced to 65,536 colors before or during compression.

TS4AlphaConverter Version 2.2 7/3/22:
- Rewrote LRLE compression to be faster, more accurate, and use less memory.
- Added a tweak to hopefully make it less likely the application will hang or become unresponsive.
- Added an option to convert RLE2 textures to LRLE, for color slider compatibility.
Note: The improvement in accuracy is real but I doubt the difference is visible to the human eye.

TS4AlphaConverter Version 2.1 6/25/22:
- Fixed bug causing all LRLE recompression to use the lower quality settings. My apologies! I still don't see any visible difference between the options but some of you might.

TS4AlphaConverter Version 2.0 6/24/22:
- Added option to recompress LRLE textures.
There's an option to use higher quality or lower quality. I can't really tell if this makes a visible difference so feedback would be helpful. I don't think there's any speed difference, but higher quality takes more memory. A PC that can run the game will probably have no problem with that.

TS4SliderConverter Version 1.1 6/24/22:
- Added options to not change filenames and not copy unchanged packages.

TS4AlphaConverter Version 1.3 6/18/22:
- Added an option to not change the filenames.
- Added filters when using the option to only update textures linked from CASPs, letting you select which kinds of items to update. Note that leaving all the filters unchecked will update all LRLE textures linked from any CASP.

Using the default of updating only hairs and skin details/overlays should be fairly safe when dealing with lots of mixed CC, but always keep the originals!

- Packages that have nothing that needs fixing will now be named "_NotFixed" if you're letting the tool rename packages.
- Will tell you how many packages were not fixed because they had nothing to fix.

TS4AlphaConverter Version 1.2 6/17/22: (Yes, two updates in one day!)
- Fixes bug causing corruption of CASPs with links directly to LRLE textures which also have extremely long part names. If your hair or overlay didn't show up in the game please try again with this version.

TS4AlphaConverter Version 1.1 6/17/22:
- Fixes question marks and (maybe) invisible parts in some converted packages.


Uses s4pi for package and image handling: https://github.com/s4ptacle/Sims4Tools/tree/develop