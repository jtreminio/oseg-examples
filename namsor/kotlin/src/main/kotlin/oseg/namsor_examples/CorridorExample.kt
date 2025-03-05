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

class CorridorExample
{
    fun corridor()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = PersonalApi().corridor(
                countryIso2From = "GB",
                firstNameFrom = "Ada",
                lastNameFrom = "Lovelace",
                countryIso2To = "US",
                firstNameTo = "Nicolas",
                lastNameTo = "Tesla",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#corridor")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#corridor")
            e.printStackTrace()
        }
    }
}
