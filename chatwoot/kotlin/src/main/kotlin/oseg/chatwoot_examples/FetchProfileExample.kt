package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class FetchProfileExample
{
    fun fetchProfile()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        try
        {
            val response = ProfileApi().fetchProfile();

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ProfileApi#fetchProfile")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ProfileApi#fetchProfile")
            e.printStackTrace()
        }
    }
}
