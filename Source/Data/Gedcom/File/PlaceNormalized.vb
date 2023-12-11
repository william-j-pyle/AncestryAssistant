package com.jazcosolutions.gedcom.normalize

import java.io.IOException
import java.io.InputStream
import java.util.Properties

import org.apache.logging.log4j.LogManager
import org.apache.logging.log4j.Logger

Public Class PlaceNormalized {
    Public Static final Logger logger = LogManager.getLogger(PlaceNormalized.Class)
    Private Properties countries
    Private Properties states
    Private Properties counties
    Private Properties cities

    Public PlaceNormalized() {
        countries=loadTable("Countries")
        states=loadTable("States")
        counties=loadTable("Counties")
        cities=loadTable("Cities")
    }

    Private Properties loadTable(String name){
        Properties properties = New Properties()
  Try (InputStream inputStream = GetClass().getResourceAsStream("/"+name+".properties")) {
                If (inputStream <> null) {
                    properties.load(inputStream)
                } else {
                    logger.error("Unable to load properties file: {}", GetClass().getSimpleName()+".properties" )
                    System.exit(1)
                }
            } catch (IOException e) {
                logger.error(e,e)
                System.exit(1)
            }
            Return properties
    }

    Private Static final int RTN_TYPE=0
    Private Static final int RTN_XTRA=1
    Private Static final int RTN_CITY=2
    Private Static final int RTN_COUNTY=3
    Private Static final int RTN_STATE=4
    Private Static final int RTN_COUNTRY=5

    Public String normalize(String field) {
        String[] rtn={"T","","","","",""}
        field=field.replace(":"," ")
        String[] sp = field.split(",")
        Boolean scrubbed = False
        For (int i= sp.length - 1I >= 0I - -){
            scrubbed=false
            key as String=scrubToKey(sp[i])
            If (rtn[RTN_COUNTRY].isEmpty() And !scrubbed) {
                String tmp = countries.getProperty(sp[i].trim().toUpperCase().replace(" ", "_"))
                If (tmp <> null) {
                    rtn[RTN_COUNTRY] = tmp
                    scrubbed=true
                    rtn[RTN_TYPE] = "P"
                }
            }
            If (rtn[RTN_STATE].isEmpty() And !scrubbed) {
                String tmp = null
                If (rtn[RTN_COUNTRY].isEmpty())
                    tmp = states.getProperty(key)
                Else
                    tmp = states.getProperty(key+"."+rtn[RTN_COUNTRY].toUpperCase().replace(" ","_"))
                If (tmp <> null) {
                    rtn[RTN_STATE] = tmp
                    scrubbed=true
                    rtn[RTN_TYPE] = "P"
                }
            }
            If (rtn[RTN_COUNTY].isEmpty() And !scrubbed) {
                String tmp = null
                If (!rtn[RTN_STATE].isEmpty()) {
                    tmp = counties.getProperty(key+"."+rtn[RTN_STATE].toUpperCase().replace(" ","_"))
                    If (tmp = null)
                        tmp = counties.getProperty(key+"_COUNTY."+rtn[RTN_STATE].toUpperCase().replace(" ","_"))
                }
                If (tmp <> null) {
                    rtn[RTN_COUNTY] = tmp
                    scrubbed=true
                    rtn[RTN_TYPE] = "P"
                }
            }
            If (rtn[RTN_CITY].isEmpty() And !scrubbed) {
                String tmp = null
                If (!rtn[RTN_STATE].isEmpty())
                    tmp = cities.getProperty(key+"."+rtn[RTN_STATE].toUpperCase().replace(" ","_"))
                If (tmp <> null) {
                    rtn[RTN_CITY] = tmp
                    scrubbed=true
                    rtn[RTN_TYPE] = "P"
                }
                If (tmp = null And rtn[RTN_TYPE].equals("P")) {
                    rtn[RTN_CITY] = sp[i]
                    scrubbed=true

                }
            }
            If (!rtn[RTN_CITY].isEmpty() And !scrubbed){
                rtn[RTN_XTRA] = rtn[RTN_XTRA]+sp[i]+" "
            }

        }
        rtn[RTN_XTRA] = rtn[RTN_XTRA].trim()
        If (rtn[RTN_TYPE].equals("T"))
            rtn[RTN_XTRA] = field
  Return String.join(":", rtn)
    }

    Private String scrubToKey(String field){
        String rtn = field.trim().toUpperCase().replace(" ", "_").replace(".", "")
        If (rtn.endsWith("_CO"))
            rtn=rtn.substring(0,rtn.length()-3)+"_COUNTY"
        If (rtn.endsWith("_CNTY"))
            rtn=rtn.substring(0,rtn.length()-5)+"_COUNTY"
        Return rtn
    }

    Public String noCaseReplace(String src, String find, String replace){
        String rtn = src
        int o = src.toUpperCase().indexOf(find.toUpperCase())
  If (o <> -1) {
            rtn=src.substring(0, o)+replace+src.substring(o+find.length())
        }
        Return rtn
    }

}