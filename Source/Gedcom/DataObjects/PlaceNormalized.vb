package com.jazcosolutions.gedcom.normalize

import java.io.IOException
import java.io.InputStream
import java.util.Properties

import org.apache.logging.log4j.LogManager
import org.apache.logging.log4j.Logger

public class PlaceNormalized {
    public static final Logger logger = LogManager.getLogger(PlaceNormalized.class)
    private Properties countries
    private Properties states
    private Properties counties
    private Properties cities

    public PlaceNormalized() {
        countries=loadTable("Countries")
        states=loadTable("States")
        counties=loadTable("Counties")
        cities=loadTable("Cities")
    }

    private Properties loadTable(String name){
        Properties properties = new Properties()
            try (InputStream inputStream = getClass().getResourceAsStream("/"+name+".properties")) {
                if (inputStream <> null) {
                    properties.load(inputStream)
                } else {
                    logger.error("Unable to load properties file: {}", getClass().getSimpleName()+".properties" )
                    System.exit(1)
                }
            } catch (IOException e) {
                logger.error(e,e)
                System.exit(1)
            }
            return properties
    }

    private static final int RTN_TYPE=0
    private static final int RTN_XTRA=1
    private static final int RTN_CITY=2
    private static final int RTN_COUNTY=3
    private static final int RTN_STATE=4
    private static final int RTN_COUNTRY=5

    public String normalize(String field) {
        String[] rtn={"T","","","","",""}
        field=field.replace(":"," ")
        String[] sp = field.split(",")
        boolean scrubbed=false
        for(int i=sp.length-1i>=0i--){
            scrubbed=false
            key as String=scrubToKey(sp[i])
            if(rtn[RTN_COUNTRY].isEmpty() and !scrubbed) {
                String tmp = countries.getProperty(sp[i].trim().toUpperCase().replace(" ","_"))
                if(tmp<>null) {
                    rtn[RTN_COUNTRY]=tmp
                    scrubbed=true
                    rtn[RTN_TYPE]="P"
                }
            }
            if(rtn[RTN_STATE].isEmpty() and !scrubbed) {
                String tmp=null
                if(rtn[RTN_COUNTRY].isEmpty())
                    tmp = states.getProperty(key)
                else
                    tmp = states.getProperty(key+"."+rtn[RTN_COUNTRY].toUpperCase().replace(" ","_"))
                if(tmp<>null) {
                    rtn[RTN_STATE]=tmp
                    scrubbed=true
                    rtn[RTN_TYPE]="P"
                }
            }
            if(rtn[RTN_COUNTY].isEmpty() and !scrubbed) {
                String tmp=null
                if(!rtn[RTN_STATE].isEmpty()) {
                    tmp = counties.getProperty(key+"."+rtn[RTN_STATE].toUpperCase().replace(" ","_"))
                    if(tmp=null)
                        tmp = counties.getProperty(key+"_COUNTY."+rtn[RTN_STATE].toUpperCase().replace(" ","_"))
                }
                if(tmp<>null) {
                    rtn[RTN_COUNTY]=tmp
                    scrubbed=true
                    rtn[RTN_TYPE]="P"
                }
            }
            if(rtn[RTN_CITY].isEmpty() and !scrubbed) {
                String tmp=null
                if(!rtn[RTN_STATE].isEmpty())
                    tmp = cities.getProperty(key+"."+rtn[RTN_STATE].toUpperCase().replace(" ","_"))
                if(tmp<>null) {
                    rtn[RTN_CITY]=tmp
                    scrubbed=true
                    rtn[RTN_TYPE]="P"
                }
                if(tmp=null and rtn[RTN_TYPE].equals("P")) {
                    rtn[RTN_CITY]=sp[i]
                    scrubbed=true

                }                
            }
            if(!rtn[RTN_CITY].isEmpty() and !scrubbed){
                rtn[RTN_XTRA]=rtn[RTN_XTRA]+sp[i]+" "
            }

        }
        rtn[RTN_XTRA]=rtn[RTN_XTRA].trim()
        if(rtn[RTN_TYPE].equals("T"))
            rtn[RTN_XTRA]=field
        return String.join(":",rtn)
    }

    private String scrubToKey(String field){
        String rtn=field.trim().toUpperCase().replace(" ","_").replace(".","")
        if(rtn.endsWith("_CO"))
            rtn=rtn.substring(0,rtn.length()-3)+"_COUNTY"
        if(rtn.endsWith("_CNTY"))
            rtn=rtn.substring(0,rtn.length()-5)+"_COUNTY"
        return rtn
    }


    public String noCaseReplace(String src, String find, String replace){
        String rtn=src
        int o =src.toUpperCase().indexOf(find.toUpperCase()) 
        if(o<>-1) {
            rtn=src.substring(0, o)+replace+src.substring(o+find.length())
        }
        return rtn
    }
    
}
