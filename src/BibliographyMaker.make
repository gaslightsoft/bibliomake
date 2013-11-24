

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=.

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/BiblographyMaker.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

BIBLOGRAPHYMAKER_EXE_MDB_SOURCE=bin/Debug/BiblographyMaker.exe.mdb
BIBLOGRAPHYMAKER_EXE_MDB=$(BUILD_DIR)/BiblographyMaker.exe.mdb
DATABASE_XML_SOURCE=database.xml
BIBMAKE_PNG_SOURCE=bibmake.png

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/BiblographyMaker.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

BIBLOGRAPHYMAKER_EXE_MDB=
DATABASE_XML_SOURCE=database.xml
BIBMAKE_PNG_SOURCE=bibmake.png

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(BIBLOGRAPHYMAKER_EXE_MDB) \
	$(DATABASE_XML) \
	$(BIBMAKE_PNG)  

BINARIES = \
	$(BIBLIOGRAPHYMAKER)  


RESGEN=resgen2

DATABASE_XML = $(BUILD_DIR)/database.xml
BIBMAKE_PNG = $(BUILD_DIR)/bibmake.png
BIBLIOGRAPHYMAKER = $(BUILD_DIR)/bibliographymaker

FILES = \
	gtk-gui/generated.cs \
	MainWindow.cs \
	Main.cs \
	AssemblyInfo.cs \
	aboutdialog.cs \
	gtk-gui/BibliographyMaker.MainWindow.cs \
	gtk-gui/BibliographyMaker.aboutdialog.cs \
	dialog.cs \
	gtk-gui/BibliographyMaker.dialog.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic 

EXTRAS = \
	app.desktop \
	database.xml \
	bib.html \
	bibmake.png \
	bibliographymaker.in 

REFERENCES =  \
	System \
	-pkg:gtk-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:glade-sharp-2.0 \
	Mono.Posix \
	System.Core \
	System.Xml \
	System.Xml.Linq \
	Mono.CSharp \
	-pkg:monodevelop

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,DATABASE_XML))
$(eval $(call emit-deploy-target,BIBMAKE_PNG))
$(eval $(call emit-deploy-wrapper,BIBLIOGRAPHYMAKER,bibliographymaker,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(BIBLOGRAPHYMAKER_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(DATABASE_XML),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(BIBMAKE_PNG),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(BIBLIOGRAPHYMAKER),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(BIBLOGRAPHYMAKER_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(DATABASE_XML),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(BIBMAKE_PNG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(BIBLIOGRAPHYMAKER),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
