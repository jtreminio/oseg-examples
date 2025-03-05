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
class Religion2Example
{
    fun religion2()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = PersonalApi().religion2(
                countryIso2 = "NG",
                subDivisionIso31662 = "IN-UP",
                firstName = "Akash",
                lastName = "Sharma",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#religion2")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#religion2")
            e.printStackTrace()
        }
    }
}
