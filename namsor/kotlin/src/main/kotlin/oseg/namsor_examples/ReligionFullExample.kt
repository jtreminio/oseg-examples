package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class ReligionFullExample
{
    fun religionFull()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = PersonalApi().religionFull(
                countryIso2 = "NG",
                subDivisionIso31662 = "IN-UP",
                personalNameFull = "Akash Sharma",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#religionFull")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#religionFull")
            e.printStackTrace()
        }
    }
}
